﻿using CarManufactoring.Models;

namespace CarManufactoring.Data
{
    public static class SeedData
    {
        internal static void Populate(CarManufactoringContext db)
        {
            PopulateSemiFinisheds(db);
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

    }
}