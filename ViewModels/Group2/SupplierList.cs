using CarManufactoring.Models;

namespace CarManufactoring.ViewModels.Group2 {
    public class SupplierList {

        public readonly static List<SupplierParts> CarPart = new List<SupplierParts>() {
            new SupplierParts{ SupplierId = 1, SupplierName="CarParts", SupplierEmail="CarParts@outlook.com", SupplierContact="932 712 231", SupplierZipCode="28600", SupplierAddress="P.º del Alparrache,  Navalcarnero, Madrid, Espanha"},
            new SupplierParts{ SupplierId = 2, SupplierName="MegaCar", SupplierEmail="MegaCar@gmail.com", SupplierContact="962 512 231", SupplierZipCode="3100", SupplierAddress="24 Bd de Courtais,  Montluçon, França"},
            new SupplierParts{ SupplierId = 3, SupplierName="BestDrive", SupplierEmail="BestDrive@hotmail.com", SupplierContact="912 112 231", SupplierZipCode="183", SupplierAddress="Piazzale Appio, 5, Roma RM, Itália"},
            new SupplierParts{ SupplierId = 4, SupplierName="NewCar", SupplierEmail="NewCar@hotmail.com", SupplierContact="942 332 231", SupplierZipCode="71000", SupplierAddress="Vrbanja 1, Sarajevo , Bósnia e Herzegovina"}
        };
    }
}
