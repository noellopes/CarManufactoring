namespace CarManufactoring.Models
{
    public class StockProduct
    {
        public int StockId { get; set; }

        public Stock Stock { get; set; }

        public int CollaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }

        public int Quantity { get; set; }

        public int StockMax { get; set; }
    }
}
