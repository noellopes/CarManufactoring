using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace CarManufactoring.Models
{
    public class SupplierProduct
    {
        //FilipeSantos-1702072
        public int SupplierId { get; set; }
        public SupplierParts Supplier {get; set;}
        public int ProductId { get; set; }
        public Product Product {get; set;}


        [Required]
        [Display(Name = "Preco")]
        public double Preco { get; set; }

        [Required]
        [Display(Name = "Prazo Entrega")]
        public DateTime PrazoEntrega { get; set; }


        [Required]
        [Display(Name = "Promocao")]
        public double Promocao { get; set; }

        [Required]
        [Display(Name = "Disponibilidade")]
        public bool Disponibilidade { get; set; }
        //Acabou
    }
}
