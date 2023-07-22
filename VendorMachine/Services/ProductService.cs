using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductStore _productStore;
        public ProductService(IProductStore productStore)
        {
            _productStore = productStore; 
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _productStore.GetProductList();
        }

        public Product GetProduct(string code)
        {
            return GetAllProducts().FirstOrDefault(x => x.ProductCode == code);
        }

        public int GetProductQuantity(string code)
        {
            var quantities = _productStore.GetInventory();
            return quantities[code];
        }

        public void UpdateProductQuantity(string code)
        {
            _productStore.UpdateInventory(code);
        }
    }
}
