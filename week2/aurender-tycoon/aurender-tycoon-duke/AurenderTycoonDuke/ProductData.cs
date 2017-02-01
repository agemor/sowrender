using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class ProductData
    {
        public string ModelName { get; }
        public string Color { get; }
        public string Capacity { get; }
        public ProductData(string modelName, string color, string capacity)
        {
            ModelName = modelName;
            Color = color;
            Capacity = capacity;
        }
    }
}
