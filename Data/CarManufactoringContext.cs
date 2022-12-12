﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarManufactoring.Models;
using static System.Reflection.Metadata.BlobBuilder;

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

            modelBuilder.Entity<SemiFinishedCar>().HasKey(bc => new { bc.SemiFinishedId, bc.CarId });
            
            modelBuilder.Entity<SemiFinishedCar>()
                .HasOne(x => x.SemiFinished)
                .WithMany(s => s.Cars)
                .HasForeignKey(x => x.SemiFinishedId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SemiFinishedCar>()
                .HasOne(x => x.Car)
                .WithMany(c => c.SemiFinisheds)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Restrict);


            // to be added == ShiftCollaborator
        }

        public DbSet<CarManufactoring.Models.Task> Task { get; set; } = default!;
        public DbSet<CarManufactoring.Models.Collaborator> Collaborator { get; set; } = default!;

        public DbSet<CarManufactoring.Models.CarParts> CarParts { get; set; }

        public DbSet<CarManufactoring.Models.MachineState> MachineState { get; set; }

        public DbSet<CarManufactoring.Models.Machines> Machines { get; set; }

        public DbSet<CarManufactoring.Models.Car> Car { get; set; }

        public DbSet<CarManufactoring.Models.SemiFinished> SemiFinished { get; set; }

        public DbSet<CarManufactoring.Models.CarConfig> CarConfig { get; set; }

        public DbSet<CarManufactoring.Models.SectionManager> SectionManager { get; set; }

        public DbSet<CarManufactoring.Models.WorkStates> WorkStates { get; set; }


        public DbSet<CarManufactoring.Models.Section> Section { get; set; }

        public DbSet<CarManufactoring.Models.MachineBudget> MachineBudget { get; set; }

        public DbSet<CarManufactoring.Models.Supplier> Supplier { get; set; }

        public DbSet<CarManufactoring.Models.MachineAquisition> MachineAquisition{ get; set; }


        public DbSet<CarManufactoring.Models.InspectionAndTest> InspectionAndTest { get; set; }


        public DbSet<CarManufactoring.Models.Extra> Extra { get; set; }

        public DbSet<CarManufactoring.Models.Material> Material { get; set; }

        public DbSet<CarManufactoring.Models.Stock> Stock { get; set; }
        public DbSet<CarManufactoring.Models.Shift> Shift { get; set; }

      

        public DbSet<CarManufactoring.Models.Customer> Customer { get; set; }

        public DbSet<CarManufactoring.Models.Order> Order { get; set; }

        public DbSet<CarManufactoring.Models.TaskType> TaskType { get; set; }

        public DbSet<CarManufactoring.Models.Brand> Brand { get; set; }

        public DbSet<CarManufactoring.Models.Production> Production { get; set; }

        public DbSet<CarManufactoring.Models.Gender> Gender { get; set; }

        public DbSet<CarManufactoring.Models.ModelParts> ModelParts { get; set; }

        public DbSet<CarManufactoring.Models.ShiftType> ShiftType { get; set; }

        public DbSet<CarManufactoring.Models.CarModels> CarModels { get; set; }

        public DbSet<CarManufactoring.Models.SemiFinishedCar> SemiFinishedCar { get; set; } = default!;

        public DbSet<CarManufactoring.Models.CustomerContact> CustomerContact { get; set; }


        public DbSet<CarManufactoring.Models.MachineBrand> MachineBrand { get; set; }

        public DbSet<CarManufactoring.Models.MachineModel> MachineModel { get; set; }



        public DbSet<CarManufactoring.Models.Breakdown> Breakdown { get; set; }

    }
}
