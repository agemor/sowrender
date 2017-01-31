using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace AurenderTycoonDuke
{
    class ProductManager
    {
        Dictionary<ProductData, ProductValue> productList = new Dictionary<ProductData, ProductValue>();

        public void MakeProductList()
        {
            DataSet ds = new DataSet();
            string connectionData = "Server = localhost; Database = sowrender; Uid = root";
            using (MySqlConnection connection = new MySqlConnection(connectionData))
            {
                string sql = "SELECT * FROM sowrender_product WHERE id >= 1";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, connection);
                adpt.Fill(ds, "sowrender_product");
            }
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Product product = new Product(r);
                productList.Add(product.productData, product.productValue);
            }
        }
        public void SetProductStock()
        {

        }
    }
}
