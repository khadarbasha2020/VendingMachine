using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Enums
{
    public enum CoinType
    {
        [Valid("InValid")]
        Pennies=1,
        [Valid("Valid")]
        Nickels = 2,
        [Valid("Valid")]
        Dimes = 3,
        [Valid("Valid")]
        Quarters = 4,
        [Valid("Valid")]
        HalfDollar = 5,
        [Valid("Valid")]
        Dollar = 6
    }
    class ValidAttribute : Attribute
    {
        public string Name { get; private set; }

        public ValidAttribute(string name)
        {
            this.Name = name;
        }
    }
}
