using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group2 {
    public class CarPartsList {

        public readonly static List<CarParts> CarPart = new List<CarParts>() {
            new CarParts{ ProductId = 1, Name="NGK LPG Laser Line 1496 Vela de ignição", PartType="Ignition", Reference="5788 / LFR6C-11", PointOfPurchase=1000, SafetyStock=400, LevelService= 0.2M},
            new CarParts{ ProductId = 1, Name="Junta, parafusos da tampa da das válvulas ELRING", PartType="motor compartment", Reference="560.490 ", PointOfPurchase=1800, SafetyStock=600, LevelService= 0.3M}

        };
    }
}
