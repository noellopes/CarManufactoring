using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class LocalizationCodeIndexViewModel
    {
        public ListViewModel<LocalizationCode> LocalizationCodeList { get; set; }

        public string? LocalizationCodeCollumnSearched { get; set; }

        public string? LocalizationCodeLineSearched { get; set; }
    }
}
