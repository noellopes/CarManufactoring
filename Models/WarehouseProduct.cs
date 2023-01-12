using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class WarehouseProduct
    {
        //Tabela intermediária entre Produto e Warehouse de muitos para muitos


        public int WarehouseId { get; set; }

        public Warehouse? Warehouses { get; set; }

        public int ProductId { get; set; }

        public CarParts? CarParts { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "StockMax must be greater than one")]
        public int StockMax { get; set; }


    }
}
