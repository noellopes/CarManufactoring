using CarManufactoring.Models;
using Microsoft.AspNetCore.Http.Connections;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;

namespace CarManufactoring.Data
{
    public static class SeedData
    {
        internal static void Populate(CarManufactoringContext db)
        {
            //PopulateSemiFinisheds(db);
            //PopulateSection(db);
            //PopulateMachineState(db);
            //PopulateMachines(db);
            PopulateCarParts(db);
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
                new MachineState { StateMachine = "Em utilização" }

                );

            db.SaveChanges();
        }

        // Seed da tabela Machine
        private static void PopulateSection(CarManufactoringContext db)
        {
            if (db.Section.Any()) return;

            db.Section.AddRange(

                new Section {Name = "Secção 1"},
                new Section { Name = "Secção 2" },
                new Section { Name = "Secção 3" },
                new Section { Name = "Secção 4" }

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

        //seed CarParts
        private static void PopulateCarParts(CarManufactoringContext db) {

            if(db.CarParts.Any()) return;

            db.CarParts.AddRange(

                new CarParts { Name = "NGK LPG Laser Line 1496 Vela de ignição", PartType = "Ignition", Reference = "5788 / LFR6C-11", PointOfPurchase = 1000, SafetyStock = 400, LevelService = 0.2M },
                new CarParts { Name = "Junta, parafusos da tampa da das válvulas ELRING", PartType = "motor compartment", Reference = "560.490 ", PointOfPurchase = 1800, SafetyStock = 600, LevelService = 0.3M}


            );
            db.SaveChanges();
        }

    }
}
