using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurenderTycoonErica
{
    class Product
    {
        /* 모델이름, 설명 */
        private string modelName;
        private string explanation;

        /* 제품 가격, 재고, 색깔, 용량 */
        private int price { get; }
        private int stock { get; }
        private string color { get; }
        private string capacity { get; }

        /* 캡슐화 */
        public string ModelName { get { return this.modelName; } }
        public string Explanation { get { return this.explanation; } }            /* 캡슐화 */
        public int Price { get { return this.price; } }
        public int Stock
        {
            get { return this.stock; }
            set { if (value >= 0) { this.Stock = value; } }
        }
        public string Color { get { return this.color; } }
        public string Capacity { get { return this.capacity; } }

        /* 생성자 */
        public Product() { }

        public Product(string modelName, string color, string capacity, int stock)
        {
            this.modelName = modelName;
            this.color = color;
            this.capacity = capacity;
            this.price = ProductManager.GetInstance().ProductInfo[modelName + color + capacity].price;
        }

        public Product(string modelName, string explanation, int price, int stock, string color, string capacity)
        {
            this.modelName = modelName;
            this.explanation = explanation;
            this.price = price;
            this.stock = stock;
            this.color = color;
            this.capacity = capacity;
        }
    }
}
