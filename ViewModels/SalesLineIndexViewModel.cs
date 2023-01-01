using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class SalesLineIndexViewModel
    {

        public ListViewModel<SalesLine> SalesLineList { get; set; }

        public int? QuantitySearched { get; set; }

        public double? PriceSearched { get; set; }

        public DateTime? DeliveryDateSearched { get; set; }

        public string? OrderSearched { get; set; }

        public string? CarConfigSearched { get; set; }

    }
}
