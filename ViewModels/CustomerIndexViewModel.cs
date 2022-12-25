using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class CustomerIndexViewModel
    {

        public ListViewModel<Customer> CustomerList { get; set; }

        public string? CustomerNameSearched { get; set; }

        public DateTime? CustomerFoundDateSearched { get; set; }

        
    }
}
