﻿using CarManufactoring.Models;

namespace CarManufactoring.Data
{
    public static class SeedData
    {
        internal static void Populate(CarManufactoringContext db)
        {

            PopulateGender(db);
            PopulateCollaborators(db);
            PopulateCarParts(db);
            PopulateSemiFinisheds(db);
            PopulateMaterials(db); 
            PopulateSection(db);
            PopulateSectionManager(db);
            PopulateMachineState(db);
            //PopulateTaskType(db);
            PopulateBrands(db);
            PopulateInspectionTesting(db);
            PopulatePriority(db);
            PopulateMachineBrand(db);
            PopulateMachineModel(db);
            PopulateMachines(db);
            //PopulateMachineMaintenance(db);
            PopulateCars(db);
            //PopulateCarConfigs(db);
            PopulateShiftType(db);
            PopulateShift(db);
            PopulateCustomers(db);
            PopulateCustomerContacts(db);
            PopulateOrder(db);
            PopulateMaterialUsed(db);
            PopulateSupplier(db);
            PopulateStocks(db);
            PopulateExtras(db);
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
                new Machine { DateAcquired = DateTime.Parse("12/03/2018"), MachineModelId = 1, MachineStateId = 1, SectionId = 2},
                new Machine { DateAcquired = DateTime.Parse("24/06/2019"), MachineModelId = 2, MachineStateId = 1, SectionId = 3 },
                new Machine { DateAcquired = DateTime.Parse("04/03/2018"), MachineModelId = 1, MachineStateId = 3, SectionId = 2 },
                new Machine { DateAcquired = DateTime.Parse("03/01/2018"), MachineModelId = 2, MachineStateId = 2, SectionId = 1 },
                new Machine { DateAcquired = DateTime.Parse("15/10/2020"), MachineModelId = 2, MachineStateId = 3, SectionId = 1 },
                new Machine { DateAcquired = DateTime.Parse("03/01/2018"), MachineModelId = 4, MachineStateId = 2, SectionId = 5 },
                new Machine { DateAcquired = DateTime.Parse("04/03/2021"), MachineModelId = 3, MachineStateId = 1, SectionId = 3 },
                new Machine { DateAcquired = DateTime.Parse("12/03/2018"), MachineModelId = 4, MachineStateId = 1, SectionId = 4 }

                );

            db.SaveChanges();
        }

        private static void PopulateMachineMaintenance(CarManufactoringContext db)
        {
            if (db.MachineMaintenance.Any()) return;

            db.MachineMaintenance.AddRange(
                 new MachineMaintenance { Description = "Manutenção periódica de Fevereiro",BeginDate = DateTime.Parse("01/02/2022"),ExpectedEndDate = DateTime.Parse("15/02/2022"), EffectiveEndDate = DateTime.Parse("15/02/2022"), TaskTypeId = 2 , PriorityId = 1, MachineId = 2},
                 new MachineMaintenance { Description = "Manutenção periódica de Março",BeginDate= DateTime.Parse("01/03/2022"), ExpectedEndDate = DateTime.Parse("12/03/2022"), EffectiveEndDate = DateTime.Parse("25/03/2022"), TaskTypeId = 2, PriorityId = 1, MachineId = 1 },
                 new MachineMaintenance { Description = "Avaria braço robótico máquina",BeginDate = DateTime.Parse("07/07/2022"),ExpectedEndDate = DateTime.Parse("12/07/2022"), EffectiveEndDate = DateTime.Parse("25/03/2022"), TaskTypeId = 1, PriorityId = 3, MachineId = 3 },
                 new MachineMaintenance { Description = "Manutenção periódica de Dezembro", ExpectedEndDate = DateTime.Parse("18/12/2022"), TaskTypeId = 2, PriorityId = 1, MachineId = 1 }

                );

            db.SaveChanges();
        }
        private static void PopulateInspectionTesting(CarManufactoringContext db)
        {
            if (db.InspectionAndTest.Any()) return;


            db.InspectionAndTest.AddRange(

                new InspectionAndTest { Date = new DateTime(2022, 12, 02, 10, 30, 50), State = "Passed on", Description = "The semi finished as passed on the test with no issues.", CollaboratorId = 1, SemiFinishedId = 1 },
                new InspectionAndTest { Date = new DateTime(2022, 12, 01, 15, 50, 10), State = "Failed", Description = "The semi finished failed the test." ,CollaboratorId = 2, SemiFinishedId = 2 },
                new InspectionAndTest { Date = new DateTime(2022, 11, 30, 11, 45, 27), State = "Testing", Description = "The semi finished is still being tested.", CollaboratorId = 3, SemiFinishedId = 3 }

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
                new Order { OrderDate = "12/10/2022", OrderState = "Pendente", StateDate = new DateTime(2022, 12, 02, 10, 30, 50), CustomerId = 1 },
                new Order { OrderDate = "10/05/2022", OrderState = "Em produçao", StateDate = new DateTime(2022, 12, 01, 15, 50, 10), CustomerId = 2 },
                new Order { OrderDate = "01/04/2022", OrderState = "Finalizada", StateDate = new DateTime(2022, 11, 30, 11, 45, 27), CustomerId = 3 }

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


        private static void PopulateSupplier(CarManufactoringContext db)
        {
            if (db.SupplierParts.Any()) return;


            db.SupplierParts.AddRange(
                new SupplierParts { Name = "CarParts", Email = "CarParts@outlook.com", Contact = "932 712 231", ZipCode = "28600", Address = "P.º del Alparrache,  Navalcarnero, Madrid, Espanha" },
                new SupplierParts { Name = "MegaCar", Email = "MegaCar@gmail.com", Contact = "962 512 231", ZipCode = "3100", Address = "24 Bd de Courtais,  Montluçon, França" },
                new SupplierParts { Name = "BestDrive", Email = "BestDrive@hotmail.com", Contact = "912 112 231", ZipCode = "183", Address = "Piazzale Appio, 5, Roma RM, Itália" },
                new SupplierParts { Name = "NewCar", Email = "NewCar@hotmail.com", Contact = "942 332 231", ZipCode = "71000", Address = "Vrbanja 1, Sarajevo , Bósnia e Herzegovina" }

                );

            db.SaveChanges();
        }
        private static void PopulateCollaborators(CarManufactoringContext db)
        {
            if (db.Collaborator.Any()) return;
            db.Collaborator.AddRange(
                new Collaborator { Name = "Worker1", BirthDate = DateTime.Parse("12 / 12 / 1999"), Phone = "919293949", Email = "Worker1@cars.pt", GenderId = 1, OnDuty = true },
                new Collaborator { Name = "Worker2", BirthDate = DateTime.Parse("12 / 12 / 1995"), Phone = "919293949", Email = "Worker2@cars.pt", GenderId = 2, OnDuty = true },
                new Collaborator { Name = "Worker3", BirthDate = DateTime.Parse("12 / 12 / 1991"), Phone = "919293949", Email = "Worker3@cars.pt", GenderId = 1, OnDuty = false }
                );
            db.SaveChanges();
        }
        private static void PopulateStocks(CarManufactoringContext db)
        {
            if (db.Stock.Any()) return;

            db.Stock.AddRange(
                new Stock { Quantity = 35, Location = "Warehouse 2", MaterialId = 1, CollaboratorId = 1 },
                new Stock { Quantity = 10, Location = "Warehouse 1", MaterialId = 2, CollaboratorId = 1 },
                new Stock { Quantity = 52, Location = "Warehouse 4", MaterialId = 3, CollaboratorId = 1 }
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


     
    }
}
