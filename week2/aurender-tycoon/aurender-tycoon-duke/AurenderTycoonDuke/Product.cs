using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke 
{
    class Product : ChangeAble
    {
        public ProductData productData { get; }
        public ProductValue productValue { get; }
        public Product(DataRow r)
        {
            this.productData = new ProductData(Convert.ToString(r["name"]), Convert.ToString(r["name"]), Convert.ToString(r["name"]));
            this.productValue = new ProductValue(Convert.ToInt32(r["price"]), Convert.ToInt32(r["stock"]),"N/A");
        }
        int ChangeAble.StringToInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
                return result;
            else
            {
                Console.WriteLine("String To Int Error - Wrong Value : " + value);
                Environment.Exit(0);
                return 0;
            }
        }
    }
}
