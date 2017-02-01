using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace AurenderTycoonDuke
{
    class ProductManager : Changeable
    {
        private static ProductManager _instance;
        protected ProductManager() { }
        static public ProductManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductManager();
            }
            return _instance;
        }

        private Dictionary<ProductData, ProductValue> productList = new Dictionary<ProductData, ProductValue>();
        static MySqlConnection connection;
        public void MakeProductList()
        {
            DataSet ds = new DataSet();
            string connectionData = "Server = localhost; Database = sowrender; Uid = root";
            if(connection == null)
                connection = new MySqlConnection(connectionData);
            string sql = "SELECT * FROM sowrender_product";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, connection);
            adpt.Fill(ds, "sowrender_product");
         
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Product product = new Product(r);
                productList.Add(product.productData, product.productValue);
            }
            foreach (var data in productList)
            {
                Console.Write(data.Key.ModelName + "|" + data.Key.Color + "|" + data.Key.Capacity + "|");
                Console.WriteLine(data.Value.Price + "|" + data.Value.Stock);
            }
        }
        public int CheckProductData(ProductData productData)
        {
            if (productList.ContainsKey(productData))
                return 0;
            else
                return -1;
        }
        public int GetProductStock(ProductData productData)
        {
            int stock = 0;
            foreach (var data in productList)
            {
                if (productData.ModelName.Equals(data.Key.ModelName, StringComparison.Ordinal) &&
                    productData.Color.Equals(data.Key.Color, StringComparison.Ordinal) &&
                    productData.Capacity.Equals(data.Key.Capacity, StringComparison.Ordinal))
                    stock = data.Value.Stock;
            }
            return stock;
        }
        public void UpdateProductStock(ProductData productData, int quantity)
        {
            foreach (var data in productList)
            {
                if (productData.ModelName.Equals(data.Key.ModelName, StringComparison.Ordinal) &&
                    productData.Color.Equals(data.Key.Color, StringComparison.Ordinal) &&
                    productData.Capacity.Equals(data.Key.Capacity, StringComparison.Ordinal))
                {
                    data.Value.Stock -= quantity;
                }
            }

            Console.WriteLine("OK");
        }        
        int Changeable.StringToInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
                return result;
            else
            {
                Console.WriteLine("String To Int Error - Wrong Value : " + value);
                Environment.Exit(0);
                return -1;
            }
        }
    }
}
