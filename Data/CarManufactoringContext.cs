using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Models;

namespace CarManufactoring.Data
{
    public class CarManufactoringContext : DbContext
    {
        public CarManufactoringContext (DbContextOptions<CarManufactoringContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CollaboratorShift>().HasKey(cs => new { cs.ShifId, cs.CollaboratorId });

            modelBuilder.Entity<CollaboratorShift>()
                .HasOne(cs => cs.Shift)
                .WithMany(c => c.Collaborators)
                .HasForeignKey(cs => cs.ShifId);

            modelBuilder.Entity<CollaboratorShift>()
                .HasOne(cs => cs.Shift)
                .WithMany(s => s.Collaborators)
                .HasForeignKey(cs => cs.ShifId);
        }

        public DbSet<CarManufactoring.Models.Collaborator> Collaborator { get; set; } = default!;

        public DbSet<CarManufactoring.Models.Shift> Shift { get; set; }

        public DbSet<CarManufactoring.Models.Task> Task { get; set; }

        public DbSet<CarManufactoring.Models.CollaboratorShift> CollaboratorShift { get; set; } = default!;

        public DbSet<CarManufactoring.Models.CarParts> CarParts { get; set; }

        public DbSet<CarManufactoring.Models.MachineState> MachineState { get; set; }

        public DbSet<CarManufactoring.Models.Machines> Machines { get; set; }

        public DbSet<CarManufactoring.Models.Car> Car { get; set; }

        public DbSet<CarManufactoring.Models.SemiFinished> SemiFinished { get; set; }

        public DbSet<CarManufactoring.Models.CarConfig> CarConfig { get; set; }

        public DbSet<CarManufactoring.Models.SectionManager> SectionManager { get; set; }

        public DbSet<CarManufactoring.Models.WorkStates> WorkStates { get; set; }

        public DbSet<CarManufactoring.Models.Client> Client { get; set; }

        public DbSet<CarManufactoring.Models.Order> Order { get; set; }

        public DbSet<CarManufactoring.Models.Section> Section { get; set; }





        public DbSet<CarManufactoring.Models.Estimate> Estimate { get; set; }





        public DbSet<CarManufactoring.Models.Extra> Extra { get; set; }

    }
}
