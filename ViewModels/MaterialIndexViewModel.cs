using CarManufactoring.Models;

namespace CarManufactoring.ViewModels
{
    public class MaterialIndexViewModel 
    {
        public ListViewModel<Material> MaterialList{ get; set; }
        public string? NomeSearched { get; set; }
        public string? TypeSearched { get; set; }
    }
    
}
