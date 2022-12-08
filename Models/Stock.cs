using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Stock
    {
        public int StockId { get; set; }

        [Required]
        [Display(Name = "Stock of material")]
        //Quantidade tem de ser um valor double para calculo deste campo Ass:Grupo2
        public double Quantity { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Location { get; set; }

        public int CollaboratorId { get; set; }

        public Collaborator? Collaborator { get; set; }

        public int MaterialId { get; set; }
        public Material? Material { get; set; }
    }
}
