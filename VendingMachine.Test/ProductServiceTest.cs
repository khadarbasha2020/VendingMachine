using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine.Test
{
    public class ProductServiceTest
    {
        private Mock<IProductStore> _productStoreService;
        [SetUp]
        public void Setup()
        {
            _productStoreService = new Mock<IProductStore>();

            
        }

        [Test]
        public void GetAllProductTest()
        {
            // Arrange
            _productStoreService.Setup(mock => mock.GetProductList()).Returns(new List<Product>());
            var productService = new ProductService(_productStoreService.Object);
            var result = productService.GetProduct("Fruit2");
            _productStoreService.Verify(m => m.GetProductList(), Times.Once);
        }
        [Test]
        public void GetAllProductsTest()
        {
            var productService = new ProductService(new ProductStore());
            var result = productService.GetAllProducts().ToList();
            // Assert
            Assert.AreEqual(result != null, true);
            Assert.Greater(result.Count, 0);
        }
        [Test]
        public void GetProductQuantityTest()
        {
            var productService = new ProductService(new ProductStore());
            var result = productService.GetProductQuantity("Fruit2");

            // Assert
            Assert.AreEqual(result, 10);
        }
        private Product CreateBananaProduct()
        {
            return new Product
            {
                ProductCode = ProductTypes.Banana.GetEnumCode(),
                ProductType = ProductTypes.Banana,
                ProductName = ProductTypes.Banana.ToString(),
                ProductPrice = 0.25m
            };
        }
    }
}
