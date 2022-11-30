using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models {
    public class CarParts:Product { // CarParts inherence the attributes from Product

        [Required]
        [StringLength(20)]
        public string CarType { get; set; } //light-duty or heavy-duty vehicle

        [Required]
        [StringLength(80, MinimumLength =3)]
        public string CarModel { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3)]
        public string CarBrand { get; set; }
    }
}
