using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class MaterialUsed
    {
        /* As tabelas SemiFinished e Material tem uma ligação de Muitos para muitos
         * Esta tabela é a tabela intermediaria entre essas duas tabelas
        */

        [Key]
        [Required]
        public int MaterialUsedId { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade precisa de um valor válido")]
        public int Quantity { get; set; }


        [Required]
        public int MaterialId { get; set; }

        [Required]
        public int SemiFinishedId { get; set; }


        public Material? Material { get; set; }

        public SemiFinished? SemiFinished { get; set; }
    }

}