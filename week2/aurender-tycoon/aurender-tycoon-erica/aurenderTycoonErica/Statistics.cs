using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurenderTycoonErica
{
    class Statistics
    {
        public string modelName;
        public string color;
        public string capacity;

        public Statistics()
        {

        }
        public Statistics(string modelName, string color, string capacity)
        {
            this.modelName = modelName;
            this.color = color;
            this.capacity = capacity;
        }

        /*총 수량*/
        public int amount = 0;

        /*총 매출*/
        public double sales = 0;
    }
}
