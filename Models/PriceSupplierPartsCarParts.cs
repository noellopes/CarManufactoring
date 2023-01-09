using MessagePack;

namespace CarManufactoring.Models
{
    public class PriceSupplierPartsCarParts
    {
        public int PriceSupplierPartsCarPartsId { get; set; }
        
        public int SupplierPartsId { get; set; }
        
        public SupplierParts? SupplierParts { get; set; }
        
        public int ProductId { get; set; }
        
        public CarParts? CarParts { get; set; }
        
        public int Preco { get; set; }
        
        public double Promocao { get; set; }
    }
}