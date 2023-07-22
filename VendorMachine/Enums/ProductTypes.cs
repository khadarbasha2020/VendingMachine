using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Enums
{
    public enum ProductTypes
    {
        [Code("Fruit1")]
        Apple = 1,
        [Code("Fruit2")]
        Banana = 2,
        [Code("Fruit3")]
        Mango = 3,
        [Code("Fruit4")]
        Kiwi = 4
    }
    class CodeAttribute : Attribute
    {
        public string Name { get; private set; }

        public CodeAttribute(string name)
        {
            this.Name = name;
        }
    }
}
