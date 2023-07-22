using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Constants;
using VendingMachine.Interfaces;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class CoinService : ICoinService
    {
        /// <summary>
        /// Returns valid coin if coin is specification matches else null
        /// </summary>
        /// <param name="coinSpecs"></param>
        /// <returns></returns>
        public ValidCoin GetCoin(CoinSpecifications coinSpecs)
        {
            return CoinsStore.AvailableCoinsList.FirstOrDefault(coin => coin.Mass == coinSpecs.Mass && coin.Thickness == coinSpecs.Thickness && coin.Diameter == coinSpecs.Diameter);
        }
    }
}
