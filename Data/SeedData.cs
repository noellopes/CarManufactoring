using CarManufactoring.Models;

namespace CarManufactoring.Data
{
    public static class SeedData
    {
        internal static void Populate(CarManufactoringContext db)
        {
            // PopulateGender(db);
            // PopulateSemiFinisheds(db);
            // PopulateSection(db);
            // PopulateSectionManager(db);
            // PopulateMachineState(db);
            // PopulateMachines(db);
            //PopulateBrands(db);
            //PopulateInspectionTesting(db);

            // PopulateCars(db);
            // PopulateCarConfigs(db);
            // PopulateShiftType(db);
            // PopulateShift(db);
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

                new SemiFinished { Family = "Filtro de óleo", Reference = "ADV182113", EAN = "5050063105056", Manufacter = "BLUE PRINT", Description = "Cartucho filtrante", SemiFinishedState = "Under Development" },
                new SemiFinished { Family = "Jogo de filtros de ar", Reference = "ADBP220039", EAN = "5057746232696", Manufacter = "BLUE PRINT", Description = "Cartucho filtrante", SemiFinishedState = "Under Development" },
                new SemiFinished { Family = "Filtro de combustível", Reference = "KL571", EAN = "4009026601778", Manufacter = "MAHLE", Description = "Filtro dos tubos", SemiFinishedState = "Under Development" },
                new SemiFinished { Family = "Jogo de pastilhas para travão de disco", Reference = "0986494956", EAN = "4047026300192", Manufacter = "BOSCH", Description = "Baixo teor metálico", SemiFinishedState = "Under Development" }

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
            if(db.SectionManager.Any()) return;
            db.SectionManager.AddRange(
                new SectionManager { Name = "Paulo Proença",BirthDate = DateTime.Parse("18 / 12 / 1985"), GenderId = 1,Phone ="961234567",Email = "pauloproenca@gmail.com",SectionId=2 }
                );

            db.SaveChanges();

        }

        // Seed da tabela Machine
        private static void PopulateMachines(CarManufactoringContext db)
        {
            if (db.Machines.Any()) return;

            db.Machines.AddRange(

                new Machines { MachineBrand = "KUKA", MachineModel = "cell4", Available = true, AquisitionDate = DateTime.Parse("30/08/2018"), MachineStateId = 1, SectionId = 1 },
                new Machines { MachineBrand = "KUKA", MachineModel = "cell4", Available = true, AquisitionDate = DateTime.Parse("12/05/2019"), MachineStateId = 1, SectionId = 1 },
                new Machines { MachineBrand = "KUKA", MachineModel = "cell4", Available = true, AquisitionDate = DateTime.Parse("23/02/2019"), MachineStateId = 1, SectionId = 2 },
                new Machines { MachineBrand = "KUKA", MachineModel = "cell4", Available = true, AquisitionDate = DateTime.Parse("03/05/2020"), MachineStateId = 1, SectionId = 3 },
                new Machines { MachineBrand = "KUKA", MachineModel = "cell4", Available = true, AquisitionDate = DateTime.Parse("12/10/2020"), MachineStateId = 1, SectionId = 2 }

                );

            db.SaveChanges();
        }


        private static void PopulateInspectionTesting(CarManufactoringContext db)
        {
            if (db.InspectionAndTest.Any()) return;


            db.InspectionAndTest.AddRange(

                new InspectionAndTest { Date = new DateTime(2022, 12, 02, 10, 30, 50), State = "Passed on", Description = "The semi finished as passed on the test with no issues." },
                new InspectionAndTest { Date = new DateTime(2022, 12, 01, 15, 50, 10), State = "Failed", Description = "The semi finished failed the test." },
                new InspectionAndTest { Date = new DateTime(2022, 11, 30, 11, 45, 27), State = "Testing", Description = "The semi finished is still being tested." }

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
                new Car { CarModel = "Model S", BasePrice = 10000, BrandId = 1, LaunchYear = 2022 },
                new Car { CarModel = "320d" , BasePrice = 15000, BrandId = 2, LaunchYear = 2022}, 
                new Car { CarModel = "G-Wagon", BasePrice = 150000, BrandId = 3, LaunchYear = 2020 },
                new Car { CarModel = "A3", BasePrice = 20000, BrandId = 4, LaunchYear = 2019},
                new Car { CarModel = "Polo", BasePrice = 18000, BrandId = 5, LaunchYear = 2018},
                new Car { CarModel = "Focus", BasePrice = 14000, BrandId = 6, LaunchYear = 2022}
                );

            db.SaveChanges() ;
        }

        // SeedData for CarConfig Class 
        private static void PopulateCarConfigs(CarManufactoringContext db)
        {
            if(db.CarConfig.Any()) return;

            db.CarConfig.AddRange(
                new CarConfig { AddedPrice = 5000, ConfigName = "Performance Line", CarId = 1, NumExtras = 5 },
                new CarConfig {  AddedPrice = 7000, ConfigName = "M Line", CarId = 2, NumExtras = 7 },
                new CarConfig {  AddedPrice = 10000, ConfigName = "Brabus ", CarId = 3, NumExtras = 8 },
                new CarConfig { AddedPrice = 7000, ConfigName = "S Line", CarId = 4, NumExtras = 6 },
                new CarConfig { AddedPrice = 5000, ConfigName = "R Line", CarId = 5, NumExtras = 4 },
                new CarConfig { AddedPrice = 5000, ConfigName = "ST Line", CarId = 6, NumExtras = 5 }
                );

            db.SaveChanges();
        }

        private static void PopulateShiftType(CarManufactoringContext db)
        {
            if(db.ShiftType.Any()) return;

            db.ShiftType.AddRange(
                new ShiftType { Description="Paint Cars from production line 1", ShiftTime = 8},
                new ShiftType { Description = "Weld car body", ShiftTime = 8 },
                new ShiftType { Description = "Install engine ", ShiftTime = 6 },
                new ShiftType { Description = "Test safety", ShiftTime = 8 },
                new ShiftType { Description = "Check brakes", ShiftTime = 6 }
                );

            db.SaveChanges();
        }

        private static void PopulateShift(CarManufactoringContext db)
        {
            if(db.Shift.Any()) return;

            db.Shift.AddRange(
                new Shift { StartDate = new DateTime(2021, 12, 02, 08, 30, 00) , EndDate = new DateTime(2021, 12, 02, 16, 30, 00), ShiftTypeId = 2 },
                new Shift { StartDate = new DateTime(2021, 1, 04, 14, 00, 00), EndDate = new DateTime(2021, 1, 05, 00, 00, 00), ShiftTypeId = 3 },
                new Shift { StartDate = new DateTime(2022, 4, 25, 00, 00, 00), EndDate = new DateTime(2022, 4, 25, 06, 00, 00), ShiftTypeId = 4 }
            );

            db.SaveChanges();
        }

        
    }
}
