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

        /* Attribute 인스턴스 저장 */
        private List<Attribute> attributeList = new List<Attribute>();

        /* 캡슐화 */
        public string ModelName { get { return this.modelName; } }
        public string Explanation { get { return this.explanation; } }
        public List<Attribute> AttributeList {
            get { return this.attributeList; }
        }

        /* List<Attribute>를 사용하기 위해 public class
         * (일관성 없는 액세스) */
        public class Attribute
        {
            /* 제품 가격, 재고, 색깔, 용량 */
            private int price { get; }
            private int stock { get; }
            private string color { get; }
            private string capacity { get; }

            /* 캡슐화 */
            public int Price { get { return this.price; } }
            public int Stock { get { return this.stock; } }
            public string Color { get { return this.color; } }
            public string Capacity { get { return this.capacity; } }

            /* 생성자 */
            public Attribute(Product p) { p.attributeList.Add(this); }
            public Attribute(Product p, string color, string capacity)
            {
                this.color = color;
                this.capacity = capacity;

                p.attributeList.Add(this);
            }
            public Attribute(Product p, int price, int stock, string color, string capacity)
            {
                this.price = price;
                this.stock = stock;
                this.color = color;
                this.capacity = capacity;

                p.attributeList.Add(this);
            }
        }
        
        /* 생성자 */
        Product(string modelName, string color, string capacity)
        {
            this.modelName = modelName;
            new Attribute(this, color, capacity);
        }

        Product(string modelName, string explanation, int price, int stock, string color, string capacity)
        {
            this.modelName = modelName;
            this.explanation = explanation;
            new Attribute(this, price, stock, color, capacity);
        }
    }
}
