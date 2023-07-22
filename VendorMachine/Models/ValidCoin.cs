using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;
using VendingMachine.Interfaces;

namespace VendingMachine.Models
{
    public class ValidCoin : CoinSpecifications
    {
        //public decimal Diameter { get; set; }
        //public decimal Mass { get; set; }
        //public decimal Thickness { get; set; }
        public CoinType Type { get; set; }
        public decimal Value { get; set; }
        public bool IsValid { get; set; }
    }
}
