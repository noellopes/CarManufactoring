using CarManufactoring.Models;
using System.Collections;

namespace CarManufactoring.ViewModels
{
    public class ProductionIndexViewModel
    {
        public ListViewModel<Production> ProductionList { get; set; }

        public ListViewModel<int> progressList { get; set; }

        public IEnumerable<CarConfig> CarConfigs { get; set; }

        public String? CarConfigSearched { get; set; }

        public int? QuantitySearched { get; set; }
    }
}
