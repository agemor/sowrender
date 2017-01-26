using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class ProductInfo
    {
        private string model;
        private string shortSubstance;

        class Product
        {
            private int price;
            private int stock;
            private string color;
            private string storage;

            public Product(int price, int stock, string color, string storage)
            {
                this.price = price;
                this.stock = stock;
                this.color = color;
                this.storage = storage;
            }
        }
    }
}
