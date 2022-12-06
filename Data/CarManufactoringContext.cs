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

            modelBuilder.Entity<CollaboratorTask>().HasKey(ct => new { ct.ShiftId, ct.TaskId, ct.CollaboratorId });
            modelBuilder.Entity<CollaboratorShift>().HasKey(cs => new { cs.ShiftId, cs.CollaboratorId });

            modelBuilder.Entity<CollaboratorShift>()
                .HasOne(cs => cs.Shift)
                .WithMany(s => s.Collaborators)
                .HasForeignKey(cs => cs.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CollaboratorShift>()
                .HasOne(ct => ct.Collaborator)
                .WithMany(s => s.Shifts)
                .HasForeignKey(cs => cs.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CollaboratorTask>()
                .HasOne(ct => ct.Task)
                .WithMany(t => t.Collaborators)
                .HasForeignKey(ct => ct.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CollaboratorTask>()
                .HasOne(ct => ct.Collaborator)
                .WithMany(c => c.Tasks)
                .HasForeignKey(ct => ct.CollaboratorId)
                .OnDelete(DeleteBehavior.Restrict);

            /*
             * modelBuilder.Entity<CollaboratorTask>()
                            .HasOne(ct => ct.Task)
                            .WithMany(c => c.Collaborators)
                            .HasForeignKey(ct => ct.TaskId);

                        modelBuilder.Entity<CollaboratorTask>()
                            .HasOne(ct => ct.Collaborator)
                            .WithMany(t => t.Tasks)
                            .HasForeignKey(cs => cs.CollaboratorId);
            */
        }
        public DbSet<CarManufactoring.Models.Collaborator> Collaborator { get; set; } = default!;

        public DbSet<CarManufactoring.Models.Shift> Shift { get; set; } = default!;

        public DbSet<CarManufactoring.Models.Task> Task { get; set; } = default!;

        public DbSet<CarManufactoring.Models.CollaboratorTask> CollaboratorTask { get; set; } = default!;

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





        public DbSet<CarManufactoring.Models.WorkMachineMaintenance> WorkMachineMaintenance { get; set; }





        public DbSet<CarManufactoring.Models.MaintenanceTask> MaintenanceTask { get; set; }


        public DbSet<CarManufactoring.Models.Material> Material { get; set; }

    }
}
