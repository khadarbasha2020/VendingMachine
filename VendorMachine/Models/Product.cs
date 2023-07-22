using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Enums;

namespace VendingMachine.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public ProductTypes ProductType { get; set; }
    }
}
