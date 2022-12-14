namespace CarManufactoring.Models
{
    public class StockProduct
    {
        public int StockId { get; set; }

        public Stock Stock { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public double Quantity { get; set; }

        public double StockMax { get; set; }
    }
}
