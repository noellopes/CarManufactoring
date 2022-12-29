using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class ProductionIndexViewModel
    {
        public ListViewModel<Production> ProductionList { get; set; }
        

        public int? CarConfigSearched { get; set; }

        public int? QuantitySearched { get; set; }
    }
}
