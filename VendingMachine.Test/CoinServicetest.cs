using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Constants;
using VendingMachine.Interfaces;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine.Test
{
    
    public class CoinServicetest
    {
        private ICoinService _coinService;
        [SetUp]
        public void Setup()
        {
            _coinService = new CoinService();
        }

        [Test]
        public void TestValidCoinObject()
        {
            var response = _coinService.GetCoin(CoinsStore.InputCoinsExampleList[1]);
            Assert.NotNull(response);
        }
        [Test]
        public void TestInValidCoinObject()
        {
            var response = _coinService.GetCoin(CoinsStore.InputCoinsExampleList[6]);
            Assert.Null(response);
        }
    }
}
