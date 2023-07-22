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
    public class VendingMachineServiceTest
    {
        private Mock<ICoinService> _coinService;
        private Mock<IProductService> _productService;
        [SetUp]
        public void Setup()
        {
            _coinService = new Mock<ICoinService>();
            _productService = new Mock<IProductService>();
        }

        [Test]
        public void AcceptCoinTest()
        {
            _coinService.Setup(m => m.GetCoin(It.IsAny<CoinSpecifications>())).Returns(CreateValidAcceptedQuartersCoin);

            VendingMachineService vendingService = new VendingMachineService(_coinService.Object, _productService.Object);
            var result = vendingService.AcceptCoin(IOHelpers.SelectCoinForInput(3));
            Assert.NotNull(result);
            Assert.False(result.IsRejectedCoin);
            Assert.AreEqual(Convert.ToDecimal(result.AmountInserted), 0.25);
            Assert.IsTrue(result.CoinName == CoinType.Quarters.ToString());
        }
        [Test]
        public void SelectProductTest()
        {
            _productService.Setup(m => m.GetProduct(It.IsAny<string>())).Returns(CreateAppleProduct);
            VendingMachineService vendingService = new VendingMachineService(_coinService.Object, _productService.Object);
            var fruit = vendingService.SelectProduct("Fruit1");
            Assert.NotNull(fruit);
        }
            
        private ValidCoin CreateValidAcceptedQuartersCoin()
        {
            return new ValidCoin()
            {
                Diameter = 24.26m,
                Thickness = 1.75m,
                Type = CoinType.Quarters,
                Mass = 5.670m,
                Value = 0.25m,
                IsValid = CoinType.Quarters.GetEnumIsValid()
            };
        }
        private Product CreateAppleProduct()
        {
            return new Product
            {
                ProductCode = ProductTypes.Apple.GetEnumCode(),
                ProductType = ProductTypes.Apple,
                ProductName = ProductTypes.Apple.ToString(),
                ProductPrice = 1.00m
            };
        }
    }
}
