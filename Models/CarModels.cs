using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class CarModels
    {

        [Key]
        public int CarModelId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string CarName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string ConfigName { get; set; }

       
    }
}
