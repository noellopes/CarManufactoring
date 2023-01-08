using CarManufactoring.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CarManufactoringContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarManufactoringContext") ?? throw new InvalidOperationException("Connection string 'CarManufactoringContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    options => {
        //Sign-in
        options.SignIn.RequireConfirmedAccount = false;

        //Password
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 8;

        //Lockout
        options.Lockout.AllowedForNewUsers = true;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        options.Lockout.MaxFailedAccessAttempts = 5;

    }
).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI();
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
} else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using(var scope = app.Services.CreateScope()) {

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    SeedData.PopulateRolesAsync(roleManager).Wait();


    if (app.Environment.IsDevelopment()) {
    
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        //SeedData.PopulateUsersAsync(userManager).Wait();

        var db = scope.ServiceProvider.GetRequiredService<CarManufactoringContext>();
        SeedData.Populate(db);
    }

}

app.Run();
