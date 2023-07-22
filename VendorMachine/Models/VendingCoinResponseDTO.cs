using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class VendingCoinResponseDTO
    {
        public string Message { get; set; }
        public string AmountInserted { get; set; }
        public bool IsRejectedCoin { get; set; }
        public InputCoins RejectedCoin { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<ChangeCoins> ChangeAmount { get; set; }
        public string CoinName { get; set; }
        public decimal NetAmount { get; set; }
        public string ProductDetails { get; set; }
    }
}
