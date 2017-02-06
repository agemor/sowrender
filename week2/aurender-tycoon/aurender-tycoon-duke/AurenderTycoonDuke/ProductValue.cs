using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class ProductValue
    {
        public int Price { get; }
        public int Stock { get; set; }
        public ProductValue(int price, int stock)
        {
            Price = price;
            Stock = stock;
        }
    }
}
