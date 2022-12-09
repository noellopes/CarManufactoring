using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ModelParts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "ID peca")]
        [Range(0, int.MaxValue, ErrorMessage = "O id da peca deve ser válido")]
        public int PecaId { get; set; }

        [Required]
        [Display(Name = "ID modelo")]
        [Range(0, int.MaxValue, ErrorMessage = "O id do modelo deve ser válido")]
        public int ModeloId { get; set; }

        [Required]
        [Display(Name = "Quantidade da peca")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de pecas deve ser acima de 0")]
        public int QtdPecas { get; set; }
    }
}
