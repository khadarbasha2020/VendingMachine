using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;

namespace VendingMachine.Models
{
    public class ChangeCoins
    {
        public CoinType Type { get; set; }
        public int Number { get; set; }
    }
}
