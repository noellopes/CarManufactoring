using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class SalesLine
    {
        public int OrderId { get; set; }
        public Order? Order{ get; set; }

        public int CarConfigId { get; set; }
        public CarConfig? CarConfig { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        public double Price { get; set; }
       
    }
}
