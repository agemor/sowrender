using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurenderTycoonErica
{
    class ProductManager
    {
        /* 모든 제품을 저장 */
        private Dictionary<string, Product> productInfo;
        static protected ProductManager _instance;

        /* 캡슐화 */
        public Dictionary<string, Product> ProductInfo { get { return this.productInfo; } }

        /* 싱글톤 */
        static public ProductManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductManager();
            }
            return _instance;
        }

        /* productInfo에 데이터세팅 */
        private void SetProductInfo()
        {
            DBManager mDBManager = DBManager.GetInstance();
            mDBManager.Connect("localhost", "sowrender", "root", "");

            string query = "SELECT model_name, model_color, model_capacity, price, stock  FROM sowrender_product";

        }

        /* 재고 관리
         * int는 재고에서 살 수 있는 수를 반환(재고가 모자른 경우)
         * p.stock이 -일 땐 구매
         * p.stock이 +일 땐 환불 */
        public int ManageStock(Product p)
        {
            string key = p.ModelName + p.Color + p.Capacity;
            Product productDB = new Product();
            productInfo.TryGetValue(key, out productDB);

            /* 재고가 떨어졌을 때 */
            if(productDB.Stock < p.Stock)
            {
                productDB.Stock = 0;
                return productDB.Stock;
            }

            productDB.Stock -= p.Stock;
            return p.Stock;
        }


    }
}
