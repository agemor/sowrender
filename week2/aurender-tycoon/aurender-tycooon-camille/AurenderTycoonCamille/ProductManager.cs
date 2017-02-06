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
     * This class manage product data
     * check the product data exist or not
     * 
     * @author  Wonjung Jeong
     * @date    2017/01/31
     */
    class ProductManager : DBManager
    {
        Dictionary<uint, ProductData> productMap = new Dictionary<uint, ProductData>();

        /* get price of order */
        /*double GetPrice()
        {
        }*/

        /* read client data at DB */
        public void ReadProduct()
        {
            string strConn = "Server = localhost;Database = sowrender;uid = camille'Pwd = 9210wonwjd;";
            MySqlConnection scon;

            using (scon = new MySqlConnection(strConn))
            {
                scon.Open();
                string sql = "SELECT * FROM product";

                MySqlCommand cmd = new MySqlCommand(sql, scon);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ProductData productData = new ProductData(dr);
                    productMap.Add(Convert.ToUInt32(dr["model_id"]), productData);
                    Console.WriteLine(dr);
                }

                dr.Close();
            }
        }

        /* find that stock is more than order amount & return price */

        double IsStockExist(string name, string color, string capacity, int order_stock)
        {
            for (uint i = 0; i < productMap.Count; i++)
            {
                if (productMap[i].model_name == name &&
                    productMap[i].model_color == color &&
                    productMap[i].model_capacity == capacity)
                {
                    if(productMap[i].stock >= order_stock)
                    {
                        return productMap[i].price;
                    }
                    else
                    {
                        Console.WriteLine("product sold out");
                    }
                }
            }
            return 0;
        }
    }
}
