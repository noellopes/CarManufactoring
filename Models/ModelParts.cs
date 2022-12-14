using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class ModelParts
    {        
        public int ModelPartsId {  get; set; }

        [Required]
        [Display(Name = "ID peca")]
        [Range(0, int.MaxValue, ErrorMessage = "O id da peca deve ser válido")]
        public int ProductId { get; set; }
        public CarParts? CarParts { get; set; }

        [Required]
        [Display(Name = "ID modelo")]
        [Range(0, int.MaxValue, ErrorMessage = "O id do modelo deve ser válido")]
        public int CarModelId { get; set; }
        public CarModels? CarModels { get; set; }

        [Required]
        [Display(Name = "Quantidade da peca")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de pecas deve ser acima de 0")]
        public int QtdPecas { get; set; }
    }
}
