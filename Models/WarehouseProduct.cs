using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class WarehouseProduct
    {
        //Tabela intermediária entre Produto e Warehouse de muitos para muitos

        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public int StockMax { get; set; }


    }
}
