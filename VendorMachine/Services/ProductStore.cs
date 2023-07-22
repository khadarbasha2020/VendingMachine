using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class ProductStore : IProductStore
    {


        private static Dictionary<string, int> _productQuantities;
        public Dictionary<string, int> GetInventory()
        {
            return _productQuantities ??
                (
                    _productQuantities = new Dictionary<string, int> {
                        { ProductTypes.Apple.GetEnumCode(), 20 },
                        { ProductTypes.Banana.GetEnumCode(), 10 }, 
                        { ProductTypes.Mango.GetEnumCode(), 15 }, 
                        { ProductTypes.Kiwi.GetEnumCode(), 0 } }
                );
        }
        public void UpdateInventory(string code)
        {
            var currentCount = _productQuantities[code];
            if (currentCount > 0)
                _productQuantities[code]--;
        }
        private static List<Product> _products;

        public IEnumerable<Product> GetProductList()
        {
            return _products ?? (_products = new List<Product>
            {
                new Product() {ProductCode = ProductTypes.Apple.GetEnumCode(), ProductType = ProductTypes.Apple, ProductName = ProductTypes.Apple.ToString(), ProductPrice = 1.00m},
                new Product() {ProductCode = ProductTypes.Banana.GetEnumCode(), ProductType = ProductTypes.Banana, ProductName = ProductTypes.Banana.ToString(), ProductPrice = 0.25m},
                new Product() {ProductCode = ProductTypes.Mango.GetEnumCode(), ProductType = ProductTypes.Mango, ProductName = ProductTypes.Mango.ToString(), ProductPrice = 0.75m},
                new Product() {ProductCode = ProductTypes.Kiwi.GetEnumCode(), ProductType = ProductTypes.Kiwi, ProductName = ProductTypes.Kiwi.ToString(), ProductPrice = 0.50m}
            });
        }
    }
}
