namespace CarManufactoring.Models
{
    public class SupplierPartsCarParts
    {
        public int SupplierPartsId { get; set; }
        public SupplierParts? SupplierParts { get; set; }

        public int ProductId { get; set; }
        public CarParts? CarParts { get; set; }

        public int PrazoEntrega { get; set; }
        public bool Disponibilidade { get; set; }
    }
}
