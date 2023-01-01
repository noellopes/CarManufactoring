using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Function
    {
        [Key]
        public int FunctionId { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Please Enter Function's Full Name!")]
        [Required(ErrorMessage = "Please Enter Function's Name!")]
        public string Name { get; set; }
    }
}
