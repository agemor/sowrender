using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class ProductData
    {
        public string modelName { get; }
        public string color { get; }
        public string capacity { get; }
        public ProductData(string modelName, string color, string capacity)
        {
            this.modelName = modelName;
            this.color = color;
            this.capacity = capacity;
        }
    }
}
