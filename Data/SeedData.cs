using CarManufactoring.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Collections.Generic;
using Task = System.Threading.Tasks.Task;

namespace CarManufactoring.Data
{
    public static class SeedData
    {
        internal static void Populate(CarManufactoringContext db)
        {


            PopulateGender(db);
            PopulateCollaborators(db);
            PopulateShiftType(db);
            PopulateShift(db);

            PopulateGender(db);
            PopulateFunction(db);
            PopulateCarParts(db);
            PopulateSemiFinisheds(db);
            //PopulateSemiFinishedCars(db);
            PopulateMaterials(db);
            PopulateSection(db);
            PopulateSectionManager(db);
            PopulateMachineState(db);
            PopulateTaskType(db);
            PopulateBrands(db);
            //PopulateInspectionTesting(db);
            //PopulateInspectionTestState(db);
            PopulatePriority(db);
            PopulateMachineBrand(db);
            PopulateMachineModel(db);
            PopulateLocalizationCode(db);
            PopulateMachines(db);
            //PopulateMachineMaintenance(db);
            PopulateCars(db);
            //PopulateTimeOfProduction(db);
            PopulateCarConfigs(db);
            PopulateCustomers(db);
            PopulateCustomerContacts(db);
            //PopulateOrder(db);
            PopulateMaterialUsed(db);
            PopulateSupplier(db);
            //PopulateStocks(db);
            PopulateWarehouseStocks(db);
            PopulateExtras(db);
            PopulateOrderState(db);
            PopulateProductions(db);
            PopulateWarehouses(db);
            PopulateModelParts(db);
            PopulateLocalizationCar(db);
            //PopulateStockFinalProduct(db);
            //PopulateBreakdows(db);
            //PopulateLocalizationCar(db);
          
            PopulateStockFinalProduct(db);
            PopulateBreakdows(db);
            PopulateBreakdows(db);
            //PopulateSupplierPartsCarParts(db);
            PopulateSupplierParts(db);

            PopulateSupplierParts(db);
            PopulateSupplierPartsCarParts(db);

        }
        internal static async Task PopulateRolesAsync(RoleManager<IdentityRole> roleManager) {
            await EnsureRoleIsCreated(roleManager, "Admin");
            await EnsureRoleIsCreated(roleManager, "Colaborator");
            await EnsureRoleIsCreated(roleManager, "ColaboratorMaintenance");
            await EnsureRoleIsCreated(roleManager, "Manager");
            await EnsureRoleIsCreated(roleManager, "Customer");
            await EnsureRoleIsCreated(roleManager, "Mechanical Eginner");
            await EnsureRoleIsCreated(roleManager, "ProdutionManager");
            await EnsureRoleIsCreated(roleManager, "Supplier");
            //await EnsureRoleIsCreated(roleManager, "Supplier Enginner");
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager, string role) {
            if(await roleManager.RoleExistsAsync(role)) {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole(role));

        }

        internal static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager) {
            var user = await EnsureUserIsCreated(userManager, "admin@ipg.pt", "Secret123$");
            await EnsureUserIsInRoleAsync(userManager, user, "Admin");

            user = await EnsureUserIsCreated(userManager, "p@ipg.pt", "Secret123$");
            await EnsureUserIsInRoleAsync(userManager, user, "ProdutionManager");

            user = await EnsureUserIsCreated(userManager, "john@ipg.pt", "Secret123$");
            await EnsureUserIsInRoleAsync(userManager, user, "Manager");

            user = await EnsureUserIsCreated(userManager, "mary@ipg.pt", "Secret123$");
            await EnsureUserIsInRoleAsync(userManager, user, "Customer");

            user = await EnsureUserIsCreated(userManager, "peter@ipg.pt", "Secret123$");
            await EnsureUserIsInRoleAsync(userManager, user,"Mechanical Eginner");

            user = await EnsureUserIsCreated(userManager, "colab@ipg.pt", "Secret123$");
            await EnsureUserIsInRoleAsync(userManager, user, "Colaborator");

            user = await EnsureUserIsCreated(userManager, "supplier@ipg.pt", "Secret");
            await EnsureUserIsInRoleAsync(userManager, user, "Supplier");

            //user = await EnsureUserIsCreated(userManager, "supplier@ipg.pt", "Secret123$");
            //await EnsureUserIsInRoleAsync(userManager, user, "Supplier Enginner");

        }

        private static async Task EnsureUserIsInRoleAsync(UserManager<IdentityUser> userManager, IdentityUser user, string role) {
            if(await userManager.IsInRoleAsync(user, role)) {
                return;
            }

            await userManager.AddToRoleAsync(user, role);
        }

        private static async Task<IdentityUser> EnsureUserIsCreated(UserManager<IdentityUser> userManager, string username, string password) {

            var user = await userManager.FindByNameAsync(username);

            if(user != null) {
                return user;
            }

            user = new IdentityUser(username);
            await userManager.CreateAsync(user, password);

            return user;
        }


        // SeedData for Material Class
        private static void PopulateMaterials(CarManufactoringContext db)
        {
            if (db.Material.Any()) return;

            db.Material.AddRange(
                new Material { Nome = "infused iron", Description = "infused iron has dimensions x,y,z and this color is gray", Type = "iron" },
                new Material { Nome = "shiny Wood", Description = "shiny Wood has dimensions x,y,z and this color is black", Type = "wood" },
                new Material { Nome = "wood piano", Description = "wood piano has dimensions x,y,z and this color is brown", Type = "wood" },
                new Material { Nome = "nappa leather", Description = "nappa leather has dimensions x,y,z and this color is white", Type = "leather" },
                new Material { Nome = "tempered glass", Description = "tempered glass has dimensions x,y,z", Type = "glass" },
                new Material { Nome = "frosted glass", Description = "frosted glass has dimensions x,y,z", Type = "glass" }
                );

            db.SaveChanges();
        }
        // seed da tabela Gender
        private static void PopulateGender(CarManufactoringContext db)
        {
            if (db.Gender.Any()) return;

            db.Gender.AddRange(
                new Gender { GenderDefinition = "Male" },
                new Gender { GenderDefinition = "Female" }
               );

            db.SaveChanges();
        }
        private static void PopulateSemiFinisheds(CarManufactoringContext db)
        {
            if (db.SemiFinished.Any()) return;

            db.SemiFinished.AddRange(

                new SemiFinished { Family = "Filtro de óleo", Reference = "ADV182113", Manufacter = "BLUE PRINT", Description = "Cartucho filtrante", SemiFinishedState = "Under Development" },
                new SemiFinished { Family = "Jogo de filtros de ar", Reference = "ADBP220039", Manufacter = "BLUE PRINT", Description = "Cartucho filtrante", SemiFinishedState = "Under Development" },
                new SemiFinished { Family = "Filtro de combustível", Reference = "KL571", Manufacter = "MAHLE", Description = "Filtro dos tubos", SemiFinishedState = "Under Development" },
                new SemiFinished { Family = "Jogo de pastilhas para travão de disco", Reference = "0986494956", Manufacter = "BOSCH", Description = "Baixo teor metálico", SemiFinishedState = "Under Development" }

                );

            db.SaveChanges();
        }

        private static void PopulateSemiFinishedCars(CarManufactoringContext db)
        {
            if (db.SemiFinishedCar.Any()) return;

            db.SemiFinishedCar.AddRange(

                new SemiFinishedCar { SemiFinishedId=1, CarId=2},
                new SemiFinishedCar { SemiFinishedId = 2, CarId = 3}

                );

            db.SaveChanges();
        }

        private static void PopulatePriority(CarManufactoringContext db)
        {
            if (db.Priority.Any()) return;

            db.Priority.AddRange(

                new Priority { Name="Baixa" },
                new Priority { Name = "Média" },
                new Priority { Name = "Alta" }

                );

            db.SaveChanges();
        }

        // Seed da tabela MachineState
        private static void PopulateMachineState(CarManufactoringContext db)
        {
            if (db.MachineState.Any()) return;

            db.MachineState.AddRange(

                new MachineState { StateMachine = "Operacional" },
                new MachineState { StateMachine = "Avariada" },
                new MachineState { StateMachine = "Em manutenção" }

                );

            db.SaveChanges();
        }


        private static void PopulateTaskType(CarManufactoringContext db)
        {
            if (db.TaskType.Any()) return;

            db.TaskType.AddRange(
                new TaskType { TaskName = "Avaria" },
                new TaskType { TaskName = "Manutenção" }   
               );

            db.SaveChanges();
        }
        // Seed da tabela Section
        private static void PopulateSection(CarManufactoringContext db)
        {
            if (db.Section.Any()) return;

            db.Section.AddRange(

                new Section { Name = "Secção 1"},
                new Section { Name = "Secção 2" },
                new Section { Name = "Secção 3" },
                new Section { Name = "Secção 4" },
                new Section { Name = "Secção 5" }
                );

            db.SaveChanges();
        }

        //Seed da tabela SectionManager

 
        private static void PopulateSectionManager(CarManufactoringContext db)
        {
            if (db.SectionManager.Any()) return;
            db.SectionManager.AddRange(
                new SectionManager { Name = "Paulo Proença", BirthDate = DateTime.Parse("18 / 12 / 1985"), GenderId = 1, Phone = "961234567", Email = "pauloproenca@gmail.com", SectionId = 2 },
                new SectionManager { Name = "Tomás Esteves", BirthDate = DateTime.Parse("05 / 08 / 1988"), GenderId = 1, Phone = "967654321", Email = "tomásesteves@gmail.com", SectionId = 1 },
                new SectionManager { Name = "Ana Vidal", BirthDate = DateTime.Parse("17 / 05 / 2001"), GenderId = 2, Phone = "96666777", Email = "tomásesteves@gmail.com", SectionId = 3 }

                );

            db.SaveChanges();

        }

        //Seed da tabela MachineBrand
        public static void PopulateMachineBrand(CarManufactoringContext db)
        {
            if (db.MachineBrand.Any()) return;
            db.MachineBrand.AddRange(
                new MachineBrand { MachineBrandName = "Kuka" },
                new MachineBrand { MachineBrandName = "Universal Robots" },
                new MachineBrand { MachineBrandName = "Omron Automation Americas" }
                );

            db.SaveChanges();
        }
        //Seed da tabela MachineModel
        public static void PopulateMachineModel(CarManufactoringContext db)
        {
            if (db.MachineModel.Any()) return;

            db.MachineModel.AddRange(
                new MachineModel { MachineModelName = "Kr Iontec", MachineBrandId = 1 },
                new MachineModel { MachineModelName = "UR10e", MachineBrandId = 3 },
                new MachineModel { MachineModelName = "Kr Cybertech", MachineBrandId = 1 },
                new MachineModel { MachineModelName = "HD-1500", MachineBrandId = 2 }
                );

            db.SaveChanges();

        }

        // Seed da tabela Machine
        private static void PopulateMachines(CarManufactoringContext db)
        {
            if (db.Machine.Any()) return;

            db.Machine.AddRange(
                //new Machine { DateAcquired = DateTime.Parse("12/03/2018"), MachineModelId = 1, MachineStateId = 1, LocalizationCodeId = 2,Description=" "},
                //new Machine { DateAcquired = DateTime.Parse("24/06/2019"), MachineModelId = 2, MachineStateId = 1, LocalizationCodeId = 3, Description = " " },
                //new Machine { DateAcquired = DateTime.Parse("04/03/2018"), MachineModelId = 1, MachineStateId = 3, LocalizationCodeId = 2, Description = " " },
                //new Machine { DateAcquired = DateTime.Parse("03/01/2018"), MachineModelId = 2, MachineStateId = 2, LocalizationCodeId = 1, Description = " " },
                //new Machine { DateAcquired = DateTime.Parse("15/10/2020"), MachineModelId = 2, MachineStateId = 3, LocalizationCodeId = 1 , Description = " " },
                //new Machine { DateAcquired = DateTime.Parse("03/01/2018"), MachineModelId = 4, MachineStateId = 2, LocalizationCodeId = 5, Description = " " },
                //new Machine { DateAcquired = DateTime.Parse("04/03/2021"), MachineModelId = 3, MachineStateId = 1, LocalizationCodeId = 3, Description = " " },
                //new Machine { DateAcquired = DateTime.Parse("12/03/2018"), MachineModelId = 4, MachineStateId = 1, LocalizationCodeId = 4, Description = " " }

                );

            db.SaveChanges();
        }

        private static void PopulateMachineMaintenance(CarManufactoringContext db)
        {
            if (db.MachineMaintenance.Any()) return;

            db.MachineMaintenance.AddRange(
                 new MachineMaintenance { Description = "Manutenção periódica de Fevereiro", BeginDate = DateTime.Parse("01/02/2022"), ExpectedEndDate = DateTime.Parse("15/02/2022"), EffectiveEndDate = DateTime.Parse("15/02/2022"), TaskTypeId = 2, PriorityId = 1, MachineId = 5 },
                 new MachineMaintenance { Description = "Manutenção periódica de Março", BeginDate = DateTime.Parse("01/03/2022"), ExpectedEndDate = DateTime.Parse("12/03/2022"), EffectiveEndDate = DateTime.Parse("25/03/2022"), TaskTypeId = 2, PriorityId = 1, MachineId = 6 },
                 new MachineMaintenance { Description = "Avaria braço robótico máquina", BeginDate = DateTime.Parse("07/07/2022"), ExpectedEndDate = DateTime.Parse("12/07/2022"), EffectiveEndDate = DateTime.Parse("25/03/2022"), TaskTypeId = 1, PriorityId = 3, MachineId = 7 },
                 new MachineMaintenance { Description = "Manutenção periódica de Dezembro", ExpectedEndDate = DateTime.Parse("18/12/2022"), TaskTypeId = 2, PriorityId = 1, MachineId = 1 }

                );

            db.SaveChanges();
        }

        private static void PopulateMaintenanceCollaborator(CarManufactoringContext db)
        {
            if (db.MaintenanceCollaborators.Any()) return;
            db.MaintenanceCollaborators.AddRange(
                new MaintenanceCollaborator { CollaboratorId=1,MachineMaintenanceId=1,BeginDate = DateTime.Parse("01/02/2022"),EffectiveEndDate = DateTime.Parse("15/02/2022") },
                new MaintenanceCollaborator { CollaboratorId=2,MachineMaintenanceId=1,BeginDate = DateTime.Parse("01/02/2022"),EffectiveEndDate = DateTime.Parse("11/02/2022") },
                new MaintenanceCollaborator { CollaboratorId = 3, MachineMaintenanceId = 3, BeginDate = DateTime.Parse("07/07/2022"), EffectiveEndDate = DateTime.Parse("25/03/2022") },
                new MaintenanceCollaborator { CollaboratorId =2,MachineMaintenanceId=3, BeginDate=DateTime.Parse("07/08/2022") }             
                );
            db.SaveChanges();
        }
        private static void PopulateInspectionTesting(CarManufactoringContext db)
        {
            if (db.InspectionAndTest.Any()) return;


            db.InspectionAndTest.AddRange(

                new InspectionAndTest { ProductionsId = 1, QuantityTested = 5, StateId = 1, Description = "The production as passed on the test with no issues.", Date = new DateTime(2022, 12, 02, 10, 30, 50), CollaboratorId = 1 },
                new InspectionAndTest { ProductionsId = 2, QuantityTested = 3, StateId = 2, Description = "The production as presented some issues.", Date = new DateTime(2023, 01, 02, 13, 30, 00), CollaboratorId = 2 },
                new InspectionAndTest { ProductionsId = 3, QuantityTested = 5, StateId = 3, Description = "The production is still being tested.", Date = new DateTime(2022, 12, 27, 17, 45, 21), CollaboratorId = 3 },
                new InspectionAndTest { ProductionsId = 4, QuantityTested = 2, StateId = 2, Description = "The production as presented some issues.", Date = new DateTime(2023, 01, 05, 09, 17, 20), CollaboratorId = 2 },
                new InspectionAndTest { ProductionsId = 2, QuantityTested = 7, StateId = 1, Description = "The production as passed on the test with no issues.", Date = new DateTime(2022, 12, 29, 10, 50, 17), CollaboratorId = 1 }

            );

            db.SaveChanges();
        }


        private static void PopulateInspectionTestState(CarManufactoringContext db)
        {
            if (db.InspectionTestState.Any()) return;

            db.InspectionTestState.AddRange(
                new InspectionTestState { State = "Passed On" },
                new InspectionTestState { State = "Failed" },
                new InspectionTestState { State = "Testing" }
            );

            db.SaveChanges();
        }

        //SeedData for Brand Class
        private static void PopulateBrands(CarManufactoringContext db)
        {
            if(db.Brand.Any()) return;

            db.Brand.AddRange(
                new Brand { BrandName= "Tesla"},
                new Brand { BrandName = "BMW" },
                new Brand { BrandName = "Mercedez" },
                new Brand { BrandName = "Audi" },
                new Brand { BrandName = "Volkswagen" },
                new Brand { BrandName = "Ford"}
                );

            db.SaveChanges();
        }

        // SeedData for Car Class 
        private static void PopulateCars(CarManufactoringContext db)
        {
            if(db.Car.Any()) return;

            db.Car.AddRange(
                new Car { CarModel = "Model S", BasePrice = 10000, BrandId = 1, LaunchYear = 2022, TimeProduction= 2},
                new Car { CarModel = "320d" , BasePrice = 15000, BrandId = 2, LaunchYear = 2022, TimeProduction = 2 }, 
                new Car { CarModel = "G-Wagon", BasePrice = 150000, BrandId = 3, LaunchYear = 2020, TimeProduction = 3 },
                new Car { CarModel = "A3", BasePrice = 20000, BrandId = 4, LaunchYear = 2019, TimeProduction = 2 },
                new Car { CarModel = "Polo", BasePrice = 18000, BrandId = 5, LaunchYear = 2018, TimeProduction = 1 },
                new Car { CarModel = "Focus", BasePrice = 14000, BrandId = 6, LaunchYear = 2022, TimeProduction = 1 }
                );

            db.SaveChanges() ;
        }

        // SeedData for CarConfig Class 
        private static void PopulateCarConfigs(CarManufactoringContext db)
        {
            if(db.CarConfig.Any()) return;

            db.CarConfig.AddRange(
                new CarConfig { AddedPrice = 5000, ConfigName = "Performance Line",FinalPrice = 15000 ,CarId = 1, NumExtras = 5 },
                new CarConfig {  AddedPrice = 7000, ConfigName = "M Line", CarId = 2,FinalPrice = 22000 ,NumExtras = 7 },
                new CarConfig {  AddedPrice = 10000, ConfigName = "Brabus ", CarId = 3,FinalPrice = 160000,NumExtras = 8 },
                new CarConfig { AddedPrice = 7000, ConfigName = "S Line", CarId = 4, FinalPrice = 27000  ,NumExtras = 6 },
                new CarConfig { AddedPrice = 5000, ConfigName = "R Line", CarId = 5, FinalPrice = 23000,NumExtras = 4 },
                new CarConfig { AddedPrice = 5000, ConfigName = "ST Line", CarId = 6, FinalPrice = 19000 ,NumExtras = 5 }
                );

            db.SaveChanges();
        }

        private static void PopulateShiftType(CarManufactoringContext db)
        {
            if(db.ShiftType.Any()) return;

            db.ShiftType.AddRange(
                new ShiftType { Description="Morninng Shift", ShiftTime = 6, StartTime = new DateTime(2022, 11, 17, 08, 00, 00) , EndTime = new DateTime(2022, 11, 17, 14, 00, 00) },
                new ShiftType { Description = "Afternoon Shift", ShiftTime = 6, StartTime = new DateTime(2022, 11, 17, 16, 00, 00), EndTime = new DateTime(2022, 11, 17, 22, 00, 00) },
                new ShiftType { Description = "Night Shift", ShiftTime = 6, StartTime = new DateTime(2022, 11, 18, 00, 00, 00), EndTime = new DateTime(2022, 11, 18, 06, 00, 00) },
                new ShiftType { Description = "Mixed Shift", ShiftTime = 8, StartTime = new DateTime(2022, 11, 17, 08, 00, 00), EndTime = new DateTime(2022, 11, 17, 16, 00, 00) }
                );

            db.SaveChanges();
        }

        private static void PopulateShift(CarManufactoringContext db)
        {
            if(db.Shift.Any()) return;

            db.Shift.AddRange(
                new Shift { StartDate = new DateTime(2021, 12, 02, 08, 00, 00) , EndDate = new DateTime(2021, 12, 02, 14, 00, 00), ShiftTypeId = 1 },
                new Shift { StartDate = new DateTime(2021, 1, 04, 16, 00, 00), EndDate = new DateTime(2021, 1, 04, 22, 00, 00), ShiftTypeId = 2 },
                new Shift { StartDate = new DateTime(2022, 4, 25, 16, 00, 00), EndDate = new DateTime(2022, 4, 25, 22, 00, 00), ShiftTypeId = 2 },
                new Shift { StartDate = new DateTime(2022, 4, 13, 00, 00, 00), EndDate = new DateTime(2022, 4, 13, 06, 00, 00), ShiftTypeId = 3 },
                new Shift { StartDate = new DateTime(2020, 7, 09, 00, 00, 00), EndDate = new DateTime(2020, 4, 09, 08, 00, 00), ShiftTypeId = 3 },
                new Shift { StartDate = new DateTime(2020, 10, 21, 08, 00, 00), EndDate = new DateTime(2020, 10, 21, 16, 00, 00), ShiftTypeId = 4}
            );

            db.SaveChanges();
        }

        private static void PopulateCustomers(CarManufactoringContext db)
        {
            if (db.Customer.Any()) return;

            db.Customer.AddRange(
                new Customer { CustomerName = "Apple", CustomerFoundDate = new DateTime(2022, 12, 02, 10, 30, 50) },
                new Customer { CustomerName = "Microsoft", CustomerFoundDate = new DateTime(2022, 12, 01, 15, 50, 10) },
                new Customer { CustomerName = "Amazon", CustomerFoundDate = new DateTime(2022, 11, 30, 11, 45, 27) }

                );

            db.SaveChanges();
        }

        private static void PopulateCustomerContacts(CarManufactoringContext db)
        {
            if (db.CustomerContact.Any()) return;

            db.CustomerContact.AddRange(
                new CustomerContact { CustomerName = "Guilherme Alves", CustomerRole = "Diretor", CustomerPhone = "+351987563215", CustomerEmail = "gui@gmail.com", CustomerId = 1 },
                new CustomerContact { CustomerName = "Luis Barros", CustomerRole = "Chefe", CustomerPhone = "+351988533215", CustomerEmail = "gui@gmail.com", CustomerId = 2 },
                new CustomerContact { CustomerName = "Rodrigo Lourenço", CustomerRole = "Tesoureiro", CustomerPhone = "+351987569053", CustomerEmail = "gui@gmail.com", CustomerId = 3 }

                );

            db.SaveChanges();
        }

        private static void PopulateOrder(CarManufactoringContext db)
        {
            if (db.Order.Any()) return;

            db.Order.AddRange(
                new Order { OrderDate = new DateTime(2022, 12, 02, 10, 30, 50), OrderStateId = 1, StateDate = new DateTime(2022, 12, 02, 10, 30, 50), CustomerId = 1 },
                new Order { OrderDate = new DateTime(2020, 12, 02, 08, 30, 10), OrderStateId = 2, StateDate = new DateTime(2022, 12, 01, 15, 50, 10), CustomerId = 2 },
                new Order { OrderDate = new DateTime(2019, 12, 03, 10, 30, 50), OrderStateId = 3, StateDate = new DateTime(2022, 11, 30, 11, 45, 27), CustomerId = 3 }

                );

            db.SaveChanges();
        }


        //seed CarParts
        private static void PopulateCarParts(CarManufactoringContext db) {

            if(db.CarParts.Any()) return;

            db.CarParts.AddRange(

                new CarParts { Name = "NGK LPG Laser Line 1496 Vela de ignição", PartType = "Ignition", Reference = "5788/LFR6C-11", PointOfPurchase = 1000, SafetyStock = 400, LevelService = 0.2M },
                new CarParts { Name = "Junta, parafusos da tampa da das válvulas ELRING", PartType = "Motor Compartment", Reference = "560.490", PointOfPurchase = 1800, SafetyStock = 600, LevelService = 0.3M},
                new CarParts { Name = "Correia dentada GATES", PartType ="Timing Belt", Reference= "5586XS", PointOfPurchase = 1000, SafetyStock = 540, LevelService = 0.4M},
                new CarParts { Name = "Jogo de pastilhas para travão de disco VALEO", PartType = "Breaks", Reference = "598891", PointOfPurchase = 900, SafetyStock = 360, LevelService = 0.27M },
                new CarParts { Name = "Rótula da barra de direcção FAG", PartType = "Suspension and Direction", Reference = "840113410", PointOfPurchase = 1500, SafetyStock = 920, LevelService = 0.45M },
                new CarParts { Name = "Kit de embraiagem LuK", PartType = "Clutch Transmission", Reference = "627158009", PointOfPurchase = 1100, SafetyStock = 840, LevelService = 0.32M }

            );
            db.SaveChanges();
        }


        private static void PopulateSupplierParts(CarManufactoringContext db)
        {
            if (db.SupplierParts.Any()) return;


            db.SupplierParts.AddRange(
                new SupplierParts { Logo = null, Name = "CarParts", Email = "CarParts@outlook.com", Contact = "932 712 231", ZipCode = "28600", Address = "P.º del Alparrache,  Navalcarnero, Madrid" , Country = "Espanha"},
                new SupplierParts { Logo = null, Name = "MegaCar", Email = "MegaCar@gmail.com", Contact = "962 512 231", ZipCode = "3100", Address = "24 Bd de Courtais,  Montluçon", Country = "França" },
                new SupplierParts { Logo = null, Name = "BestDrive", Email = "BestDrive@hotmail.com", Contact = "912 112 231", ZipCode = "183", Address = "Piazzale Appio, 5, Roma RM" , Country = "Itália" },
                new SupplierParts { Logo = "https://i.pinimg.com/736x/19/73/c4/1973c4f86b4c85ba87006fc0a4bdaf50.jpg", Name = "Toyota Parts", Email = "Toyota@hotmail.com", Contact = "942 332 231", ZipCode = "71000", Address = "Vrbanja 1, Sarajevo", Country = "Bósnia" },
                new SupplierParts { Logo = "https://th.bing.com/th/id/OIP.p2rJ5FCz6SjTf1v1riX7awHaHP?pid=ImgDet&rs=1", Name = "Bosch Pieces", Email = "Bosch@hotmail.com", Contact = "942 332 231", ZipCode = "71000", Address = "Vrbanja 1, Sarajevo", Country = "Bósnia" }
                );


            db.SaveChanges();
        }

        private static void PopulateSupplier(CarManufactoringContext db)
        {
            if (db.Supplier.Any()) return;


            db.Supplier.AddRange(
                new Supplier { SupplierName = "BOCH", SupplierEmail = "BoschCarService@outlook.com", SupplierContact = "+351 271 213 862", SupplierZipCode = "6300-877", SupplierAddress = "Quinta da Torre, Guarda, Portugal" },
                new Supplier { SupplierName = "COFICAB", SupplierEmail = "Coficab@gmail.com", SupplierContact = "+351 271 205 090", SupplierZipCode = "6300-230", SupplierAddress = "Vale de Estrela, Guarda, Portugal" },
                new Supplier { SupplierName = "SODECIA", SupplierEmail = "SODECIA@hotmail.com", SupplierContact = "+351 271 222 470", SupplierZipCode = "6300-625", SupplierAddress = "Parque Industrial da Guarda, Guarda, Portugal" }
                );

            db.SaveChanges();
        }


        private static void PopulateCollaborators(CarManufactoringContext db)
        {
            if (db.Collaborator.Any()) return;
            db.Collaborator.AddRange(
                new Collaborator { Name = "Mustafa Bukhari", BirthDate = DateTime.Parse("09 / 11 / 1999"), Phone = "+351936584254", Email = "mustafabukhari@cars.pt", GenderId = 1, OnDuty = true, Status = "Not Available" },
                new Collaborator { Name = "Elizabeth Cady", BirthDate = DateTime.Parse("04 / 07 / 2000"), Phone = "+351496251487", Email = "elizabethcady@cars.pt", GenderId = 2, OnDuty = true, Status = "Not Available" },
                new Collaborator { Name = "Joseph Vissari", BirthDate = DateTime.Parse("12 / 06 / 1989"), Phone = "+351930706133", Email = "josephvissari@cars.pt", GenderId = 1, OnDuty = true, Status = "Not Available" },
                new Collaborator { Name = "Lisa Holland", BirthDate = DateTime.Parse("10 / 02 / 1991"), Phone = "+351970560731", Email = "lisaholland@cars.pt", GenderId = 2, OnDuty = false, Status = "Not Available" },
                new Collaborator { Name = "Haris  Howell", BirthDate = DateTime.Parse("11 / 09 / 1997"), Phone = "+351996321856", Email = "harishowel@cars.pt", GenderId = 1, OnDuty = true, Status = "Not Available" },
                new Collaborator { Name = "Thea Moss", BirthDate = DateTime.Parse("06 / 12 / 1995"), Phone = "+351951357488", Email = "theamoss@cars.pt", GenderId = 2, OnDuty = false, Status = "Available" },
                new Collaborator { Name = "James Mcgee", BirthDate = DateTime.Parse("07 / 10 / 1998"), Phone = "+351987535926", Email = "jamesmcgee@cars.pt", GenderId = 1, OnDuty = false, Status = "Available" },
                new Collaborator { Name = "Luck Brown", BirthDate = DateTime.Parse("02 / 05 / 1997"), Phone = "+351954852358", Email = "luckbrown@cars.pt", GenderId = 1, OnDuty = true, Status = "Not Available" },
                new Collaborator { Name = "Kyle Hoffman", BirthDate = DateTime.Parse("06 / 08 / 1996"), Phone = "+351987565233", Email = "kylehoffman@cars.pt", GenderId = 1, OnDuty = false, Status = "Available" }
                );
            db.SaveChanges();
        }
        private static void PopulateStocks(CarManufactoringContext db)
        {
            if (db.Stock.Any()) return;

            db.Stock.AddRange(
                new Stock { Quantity = 35, Location = "Warehouse 2", MaterialId = 1, Description = "This is a text sample", WarehouseStockId = 1 },
                new Stock { Quantity = 10, Location = "Warehouse 1", MaterialId = 2, Description = "This is a text sample", WarehouseStockId = 4 },
                new Stock { Quantity = 52, Location = "Warehouse 4", MaterialId = 3, Description = "This is a text sample", WarehouseStockId = 2 }
                );

            db.SaveChanges();
        }

        private static void PopulateWarehouseStocks(CarManufactoringContext db)
        {
            if (db.WarehouseStock.Any()) return;

            db.WarehouseStock.AddRange(
                new WarehouseStock { Identification = "Warehouse nº 1"},
                new WarehouseStock { Identification = "Warehouse nº 2" },
                new WarehouseStock { Identification = "Warehouse nº 3" },
                new WarehouseStock { Identification = "Warehouse nº 4" }


                );

            db.SaveChanges();
        }

        private static void PopulateMaterialUsed(CarManufactoringContext db)
        {
            if (db.MaterialUsed.Any()) return;

            db.MaterialUsed.AddRange(
                new MaterialUsed { MaterialId = 1, SemiFinishedId = 1, Quantity = 10 },
                new MaterialUsed { MaterialId = 2, SemiFinishedId = 1, Quantity = 23 },
                new MaterialUsed { MaterialId = 3, SemiFinishedId = 1, Quantity = 2 },
                new MaterialUsed { MaterialId = 2, SemiFinishedId = 2, Quantity = 8 },
                new MaterialUsed { MaterialId = 3, SemiFinishedId = 2, Quantity = 14 }
            );

            db.SaveChanges();
        }

        public static void PopulateExtras (CarManufactoringContext db)
        {
            if (db.Extra.Any()) return;

            db.Extra.AddRange(

            new Extra { DescExtra = "Jantes", Price = 5000 },
            new Extra { DescExtra = "Manetes Carbono", Price = 4000 },
            new Extra { DescExtra = "Bancos em pele", Price = 7000 },
            new Extra { DescExtra = "Aleron", Price = 3000 },
            new Extra { DescExtra = "Sensores de estacionamento", Price = 5000 }

            );

            db.SaveChanges();
        }

        private static void PopulateOrderState(CarManufactoringContext db)
        {
            if (db.OrderState.Any()) return;

            db.OrderState.AddRange(
                new OrderState { OrderStateName = "Pendente" },
                new OrderState { OrderStateName = "Em Produçao" },
                new OrderState { OrderStateName = "Finalizado" },
                new OrderState { OrderStateName = "Cancelado" }
                );

            db.SaveChanges();
        }

        private static void PopulateSalesLine(CarManufactoringContext db)
        {
            if (db.SalesLine.Any()) return;

            db.SalesLine.AddRange(
                new SalesLine { OrderId = 1, CarConfigId = 1, Price = 150000, Quantity = 10, DeliveryDate = DateTime.Parse("12/02/2022")},
                new SalesLine { OrderId = 2, CarConfigId = 1, Price = 30000, Quantity = 2, DeliveryDate = DateTime.Parse("02/01/2022")},
                new SalesLine { OrderId = 3, CarConfigId = 2, Price = 220000, Quantity = 10, DeliveryDate = DateTime.Parse("12/03/2023")},
                new SalesLine { OrderId = 4, CarConfigId = 2, Price = 44000, Quantity = 2, DeliveryDate = DateTime.Parse("03/01/2023")}
                );

            db.SaveChanges();
        }

        private static void PopulateProductions(CarManufactoringContext db)
        {
            if (db.Production.Any()) return;

            db.Production.AddRange(
                new Production { Date = DateTime.Parse("13/02/2022"), CarConfigId = 1, Quantity= 10 },
                new Production { Date = DateTime.Parse("02/01/2022"), CarConfigId = 1, Quantity = 2 },
                new Production { Date = DateTime.Parse("12/03/2023"), CarConfigId = 2, Quantity = 10 },
                new Production { Date = DateTime.Parse("03/01/2023"), CarConfigId = 2, Quantity = 2 }
                );

            db.SaveChanges();
        }

        private static void PopulateLocalizationCode(CarManufactoringContext db)
        {
            if (db.LocalizationCode.Any()) return;

            db.LocalizationCode.AddRange(
                new LocalizationCode { Column = "A", Line = "1" },
                new LocalizationCode { Column = "A", Line = "2" },
                new LocalizationCode { Column = "A", Line = "3" },
                new LocalizationCode { Column = "B", Line = "1" },
                new LocalizationCode { Column = "B", Line = "2" },
                new LocalizationCode { Column = "B", Line = "3" }
                );

            db.SaveChanges();

        }

        private static void PopulateFunction(CarManufactoringContext db)
        {
            if (db.Function.Any()) return;

            db.Function.AddRange(
                new Function { Name = "Limpar Peça" },
                new Function { Name = "Montar Peça" }
                );

            db.SaveChanges();

        }
        private static void PopulateWarehouses(CarManufactoringContext db)
        {
            if (db.Warehouse.Any()) return;

            db.Warehouse.AddRange(
                new Warehouse { Location = "Guarda", CollaboratorID = 1 },
                new Warehouse { Location = "Lisboa", CollaboratorID = 2 },
                new Warehouse { Location = "Porto", CollaboratorID = 3 }
                );

            db.SaveChanges();
        }

        private static void PopulateModelParts(CarManufactoringContext db)
        {
            if(db.ModelParts.Any()) return;

            db.ModelParts.AddRange(
                    new ModelParts { CarConfigId = 1, ProductId = 1, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 1, ProductId = 2, QtdPecas = 135 },
                    new ModelParts { CarConfigId = 1, ProductId = 3, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 1, ProductId = 4, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 1, ProductId = 5, QtdPecas = 4 },
                    new ModelParts { CarConfigId = 1, ProductId = 6, QtdPecas = 1},
                    new ModelParts { CarConfigId = 2, ProductId = 1, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 2, ProductId = 2, QtdPecas = 135 },
                    new ModelParts { CarConfigId = 2, ProductId = 3, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 2, ProductId = 4, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 2, ProductId = 5, QtdPecas = 4 },
                    new ModelParts { CarConfigId = 2, ProductId = 6, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 3, ProductId = 1, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 3, ProductId = 2, QtdPecas = 135 },
                    new ModelParts { CarConfigId = 3, ProductId = 3, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 3, ProductId = 4, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 3, ProductId = 5, QtdPecas = 4 },
                    new ModelParts { CarConfigId = 3, ProductId = 6, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 4, ProductId = 1, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 4, ProductId = 2, QtdPecas = 135 },
                    new ModelParts { CarConfigId = 4, ProductId = 3, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 4, ProductId = 4, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 4, ProductId = 5, QtdPecas = 4 },
                    new ModelParts { CarConfigId = 4, ProductId = 6, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 5, ProductId = 1, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 5, ProductId = 2, QtdPecas = 135 },
                    new ModelParts { CarConfigId = 5, ProductId = 3, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 5, ProductId = 4, QtdPecas = 1 },
                    new ModelParts { CarConfigId = 5, ProductId = 5, QtdPecas = 4 },
                    new ModelParts { CarConfigId = 5, ProductId = 6, QtdPecas = 1 }
            );

            db.SaveChanges();
        }

        private static void PopulateTimeOfProduction(CarManufactoringContext db)
        {
            if (db.TimeOfProduction.Any()) return;

            db.TimeOfProduction.AddRange(
                new TimeOfProduction { CarConfigId = 1, Time = 2 },
                new TimeOfProduction { CarConfigId = 2, Time = 1 },
                new TimeOfProduction { CarConfigId = 3, Time = 3},
                new TimeOfProduction { CarConfigId = 4, Time = 1},
                new TimeOfProduction { CarConfigId = 5, Time = 4 }
                );
            
        }

        private static void PopulateLocalizationCar(CarManufactoringContext db)
        {
            if (db.LocalizationCar.Any()) return;

            db.LocalizationCar.AddRange(
                new LocalizationCar { Line = "1", Row = "1", IsOccupied = false },
                new LocalizationCar { Line = "1", Row = "2", IsOccupied = false },
                new LocalizationCar { Line = "1", Row = "3", IsOccupied = false },
                new LocalizationCar { Line = "1", Row = "4", IsOccupied = false },
                new LocalizationCar { Line = "2", Row = "1", IsOccupied = false },
                new LocalizationCar { Line = "2", Row = "2", IsOccupied = false },
                new LocalizationCar { Line = "2", Row = "3", IsOccupied = false },
                new LocalizationCar { Line = "2", Row = "4", IsOccupied = false },
                new LocalizationCar { Line = "3", Row = "1", IsOccupied = false },
                new LocalizationCar { Line = "3", Row = "2", IsOccupied = false },
                new LocalizationCar { Line = "3", Row = "3", IsOccupied = false },
                new LocalizationCar { Line = "3", Row = "4", IsOccupied = false },
                new LocalizationCar { Line = "4", Row = "1", IsOccupied = false },
                new LocalizationCar { Line = "4", Row = "2", IsOccupied = false },
                new LocalizationCar { Line = "4", Row = "3", IsOccupied = false },
                new LocalizationCar { Line = "4", Row = "4", IsOccupied = false }
                );
            db.SaveChanges();
        }

        private static void PopulateStockFinalProduct(CarManufactoringContext db)
        {

            if (db.StockFinalProduct.Any()) return;

            db.StockFinalProduct.AddRange(
                new StockFinalProduct { ChassiNumber = "1", LocalizationCarId = 1, ProductionId = 1, InsertionDate = DateTime.Parse("13/02/2022") },
                new StockFinalProduct { ChassiNumber = "2", LocalizationCarId = 2, ProductionId = 2, InsertionDate = DateTime.Parse("13/02/2022") },
                new StockFinalProduct { ChassiNumber = "3", LocalizationCarId = 3, ProductionId = 3, InsertionDate = DateTime.Parse("13/02/2022") },
                new StockFinalProduct { ChassiNumber = "4", LocalizationCarId = 4, ProductionId = 4, InsertionDate = DateTime.Parse("13/02/2022") }


                );
            db.SaveChanges();
        }

        private static void PopulateSupplierPartsCarParts(CarManufactoringContext db)
        {
            if (db.SupplierPartsCarParts.Any()) return;
            //Aproveitando a ideia do professor, como a ordem importa
            //Caso não exista a tabela SupplierParts e CarParts é chamada a funçãi para criar a mesmo e depois sim criar a tabela intermedia
            if (!db.SupplierParts.Any()) PopulateSupplierParts(db);
            if (!db.CarParts.Any()) PopulateCarParts(db);

            Random rnd = new Random();
            int dias;
            int disp;


            foreach (SupplierParts sp in db.SupplierParts.ToArray())
            {
                foreach (CarParts cp in db.CarParts.ToArray())
                {
                    dias = rnd.Next(1, 31);
                    disp = rnd.Next(0, 2);
                    db.SupplierPartsCarParts.AddRange(
                        new SupplierPartsCarParts { ProductId = cp.ProductId, SupplierPartsId = sp.SupplierPartsId, PrazoEntrega = dias, Disponibilidade = Convert.ToBoolean(disp) }
                    );
                }
            };
            db.SaveChanges();
        }


        private static void PopulateBreakdows(CarManufactoringContext db)
        {
            if (db.Breakdown.Any()) return;

            db.Breakdown.AddRange(

               new Breakdown
               {
                   BreakdownName = "Fuga de Fluido",
                   BreakdownDate = DateTime.Parse("13/02/2022"),
                   BreakdownNumber = 1,
                   ReparationDate = DateTime.Parse("13/02/2022"),
                   MachineStop = 4,
                   MachineReplacement =MachineReplacement.Replacement,
                   RepairInTheCompany = true
               },

                new Breakdown
                {
                    BreakdownName = "Trasmissão - Guarda-pó muito deteriorada",
                    BreakdownDate = DateTime.Parse("01/01/2023"),
                    BreakdownNumber = 2,
                    ReparationDate = DateTime.Parse("03/01/2023"),
                    MachineStop = 12,
                    MachineReplacement = MachineReplacement.Repair,
                    RepairInTheCompany = true
                },
                 new Breakdown
                 {
                     BreakdownName = "Alinhamento das rodas direcionais, Alinhamento dos medios, Maximo e médio - Sistema de projeção",
                     BreakdownDate = DateTime.Parse("13/01/2023"),
                     BreakdownNumber = 3,
                     ReparationDate = DateTime.Parse("16/01/2023"),
                     MachineStop = 12,
                     MachineReplacement =MachineReplacement.Replacement,
                     RepairInTheCompany = false
                 },
                 new Breakdown
                 {
                     BreakdownName = "Sistema de projeção",
                     BreakdownDate = DateTime.Parse("13/02/2022"),
                     BreakdownNumber = 3,
                     ReparationDate = DateTime.Parse("13/02/2022"),
                     MachineStop = 12,
                     MachineReplacement = MachineReplacement.Replacement,
                     RepairInTheCompany = false
                 }


                );

            db.SaveChanges();
        }
        
    }
}
