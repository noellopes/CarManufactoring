using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class CustomerContactsIndexViewModel
    {
      
        public ListViewModel<CustomerContact> CustomerContactList { get; set; }

        public string? CustomerContactNameSearched { get; set; }

        public string? CustomerRoleSearched { get; set; }

        public string? CustomerPhoneSearched { get; set; }

        public string? CustomerEmailSearched { get; set; }

        public string? CustomerSearched { get; set; }






    }
}
