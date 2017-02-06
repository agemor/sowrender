using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace AurenderTycoon
{
    /**
     * This class define key of product data
     * 
     * @author  Wonjung Jeong
     * @date    2017/01/31
     */
     /*
    class ProductKey
    {
        public uint model_id { get; }
        public string model_name { get; }
        public string model_color { get; }
        public string model_capacity { get; }

        public ProductKey(uint id, string name, string color, string capacity)
        {
            model_id = id;
            model_name = name;
            model_color = color;
            model_capacity = capacity;
        }
    }
    class ProductValue
    {
        public double price { get; }
        public int stock { get; }

        public ProductValue(double price, int stock)
        {
            this.price = price;
            this.stock = stock;
        }
    }
    */
    class ProductData
    {
        public string model_name { get; }
        public string model_color { get; }
        public string model_capacity { get; }
        public double price { get; }
        public int stock { get; }

        public ProductData(MySqlDataReader dr)
        {
            model_name = Convert.ToString(dr["model_name"]);
            model_color = Convert.ToString(dr["model_color"]);
            model_capacity = Convert.ToString(dr["model_capacity"]);
            price = Convert.ToDouble(dr["price"]);
            stock = Convert.ToInt32(dr["stock"]);
        }
    }

}