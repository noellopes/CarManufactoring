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

        public DbSet<CarManufactoring.Models.Collaborator> Collaborator { get; set; } = default!;

        public DbSet<CarManufactoring.Models.CarParts> CarParts { get; set; }

        public DbSet<CarManufactoring.Models.MachineState> MachineState { get; set; }

        public DbSet<CarManufactoring.Models.Machines> Machines { get; set; }

        public DbSet<CarManufactoring.Models.Car> Car { get; set; }

        public DbSet<CarManufactoring.Models.SemiFinished> SemiFinished { get; set; }

        public DbSet<CarManufactoring.Models.Assigment> Assigment { get; set; }

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
