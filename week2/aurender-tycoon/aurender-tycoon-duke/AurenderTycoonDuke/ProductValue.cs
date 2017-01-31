using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class ProductValue
    {
        public int price { get; }
        public int stock { get; set; }
        public string shortInformation { get; }
        public ProductValue(int price, int stock, string shortInformation)
        {
            this.price = price;
            this.stock = stock;
            this.shortInformation = shortInformation;
        }
    }
}
