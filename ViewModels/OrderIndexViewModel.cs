using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class OrderIndexViewModel
    {
        public ListViewModel<Order> OrderList { get; set; }

        public DateTime? OrderDateSearched { get; set; }

        public string? OrderStateSearched { get; set; }

        public DateTime? StateDateSearched { get; set; }

        public string CustomerSearched { get; set; }

    }
}
