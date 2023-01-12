using CarManufactoring.Data;
using CarManufactoring.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManufactoring.Models {
    public abstract class Product {

        [Key] // This is needed so the program knows what is the primary key of the descendants
        public int ProductId { get; set; }

        [Required]
        [StringLength(20,MinimumLength =3)]
        public string Reference { get; set; }

        [Required]
        [StringLength(120, MinimumLength =4)]
        public string Name { get; set; }

        public double PointOfPurchase { get; set; }

        [Required]
        public double SafetyStock { get; set; }

        [Range(0,1)]
        public decimal LevelService { get; set; }

        [NotMapped]
        public string StockState { get; set; } = "to Implement"; //Wait for stockStorage to be done

        public static IOrderedQueryable<CarParts> SearchProd(CarManufactoringContext context, string NameSearch, string TypeSearch, string referenceSearch, string BrandSearch, string ModelSearch) {

            var carPart = context.CarParts
                    .Where(cp => BrandSearch == null || cp.CarConfig.All(c => c.CarConfig.Car.Brand.BrandName.Contains(BrandSearch)))
                    .Where(cp => ModelSearch == null || cp.CarConfig.All(c => c.CarConfig.Car.CarModel.Contains(ModelSearch)))
                    .Where(cp => NameSearch == null || cp.Name.Contains(NameSearch))
                    .Where(cp => TypeSearch == null || cp.PartType.Contains(TypeSearch))
                    .Where(cp => referenceSearch == null || cp.Reference.Contains(referenceSearch))
                    .OrderBy(cp => cp.Name);

            return carPart;

        }

        public static void SetPointP(CarManufactoringContext context, int prodId, int supId) {

            double dd = 500;

            //CarPart
            var cp= context.CarParts
                .Where(cp => cp.ProductId.Equals(prodId));

            //DeliveryTime
            var dt = context.SupplierPartsCarParts
                .Where(spcp => spcp.SupplierPartsId.Equals(supId))
                .Where(spcp => spcp.ProductId.Equals(prodId))
                .Select(spcp => spcp.PrazoEntrega);

            double DT = Convert.ToDouble(dt);

            //Safety Stock
            var ss = cp.Select(cp => cp.SafetyStock);
            double SS = Convert.ToDouble(ss);

            double PointPurchase = dd + (SS * DT);

            context.CarParts.First(cp => cp.ProductId.Equals(prodId)).PointOfPurchase = PointPurchase;
            
        }


        //MaxQuant - 50% LevelService
        //CurrentQuant - x
        //x = (Quant*0.5)/Maxquant

        public static void setLevelService(CarManufactoringContext context, int prodId) {

            double maxLevelService = 0.5; //50%

            //car part
            var cp = context.CarParts
                .Where(cp => cp.ProductId.Equals(prodId));

            //wh
            var wh = context.WarehouseProduct
                .Where(wh => wh.ProductId.Equals(prodId));

            var whMaxLS = wh.Sum(wh => wh.StockMax);
            double MaxQuant = Convert.ToDouble(whMaxLS);

            var whCurrentQuant = wh.Sum(wh => wh.Quantity);
            double currentQuant = Convert.ToDouble(whCurrentQuant);

            decimal levelService = (decimal)((currentQuant * maxLevelService) / MaxQuant);

            context.CarParts.First(cp => cp.ProductId.Equals(prodId)).LevelService = levelService;

        }

        //Filipe will do the buyProdfunction
    }
}
