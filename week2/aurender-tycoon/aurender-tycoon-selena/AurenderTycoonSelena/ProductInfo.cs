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
        private uint price;
        private int stock;
        private string color;
        private string storage;

        public string Model { get { return this.model; } }
        public uint Price { get { return this.price; } }
        public int Stock { get { return this.stock; } set { stock = value; } }
        public string Color { get { return this.color; } }
        public string Storage { get { return this.storage; } }

        public ProductInfo(string lines)
        /* example lines data = "no,model_name,price,finish,storage,stock" */
        {
            string[] data = lines.Split(',');

            this.model = data[1];
            this.price = uint.Parse(data[2]);
            this.color = data[3];
            this.storage = data[4];
            this.stock = int.Parse(data[5]); // stock에 N/A값 들어가있음
        }
    }
}
