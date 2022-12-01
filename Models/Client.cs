using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(100, MinimumLength = 10)]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Sex")]
        [StringLength(9, MinimumLength = 8)]
        public string ClientSex { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime ClientDataNasc { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(13)]
        [Phone]
        public string ClientContact { get; set; }

    }
}
