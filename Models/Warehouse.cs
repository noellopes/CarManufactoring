using System.ComponentModel.DataAnnotations;


namespace CarManufactoring.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        [Required]
        public string Location { get; set; }

        [Display(Name = "Collaborator")]
        public int CollaboratorID { get; set; }

        public Collaborator Collaborator { get; set; }
    }
}
