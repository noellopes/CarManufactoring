using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models {
    public class RegisterExample {

        [Required, StringLength(128)]
        public string Name { get; set; }

        [Required, StringLength(256)]
        public string email { get; set; }

        [Required, StringLength(128)]
        public string password { get; set; }

        [Required, StringLength(128)]
        [Compare("password", ErrorMessage = "The passwords must match")]
        public string confirmPassword { get; set; }
    }
}
