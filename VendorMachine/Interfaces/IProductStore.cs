using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.Interfaces
{
    public interface IProductStore
    {
        IEnumerable<Product> GetProductList();
        Dictionary<string, int> GetInventory();
        void UpdateInventory(string code);
    }
}
