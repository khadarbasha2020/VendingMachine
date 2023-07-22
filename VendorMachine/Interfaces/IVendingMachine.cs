using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface  IVendingMachine
    {
        VendingCoinResponseDTO AcceptCoin(InputCoins coin);
        VendingCoinResponseDTO SelectProduct(string code);
        IEnumerable<ChangeCoins> ReturnCoinsChange();
        IEnumerable<ChangeCoins> ReturnRejectedValidCoin();

    }
}
