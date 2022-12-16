using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class SalesLine
    {
        public int SalesLineId { get; set; }
        public int OrderId { get; set; }
        public Order? Order{ get; set; }

        public int CarId { get; set; }
        public Car? Car { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
