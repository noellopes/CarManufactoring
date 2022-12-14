using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ConfigList
    {
       
        public int ConfigListId { get; set; }

        [Required]
        public int CarConfigId { get; set; }
        public CarConfig? CarConfig { get; set; }

        [Required]
        public int ExtraId { get; set; }
        public Extra? Extra { get; set; }



    }
}
