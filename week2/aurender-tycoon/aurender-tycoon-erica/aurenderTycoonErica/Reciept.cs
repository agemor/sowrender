using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurenderTycoonErica
{
    class Reciept
    {
        /* 모델, 색깔, 용량, 가격 */
        private string modelName;
        private string modelColor;
        private string capacity;
        private int price;

        /* 손님이 산 갯수, 날짜 */
        private int amount;
        private DateTime date;

        /* 손님 정보 */
        private Customer customerData;

        /* 캡슐화 */
        public string ModelName { get { return this.modelName; } }
        public string ModelColor { get { return this.modelColor; } }
        public string Capacity { get { return this.capacity; } }
        public int Price { get { return this.price; } }
        public int Amount { get { return this.amount; } }
        public DateTime Date { get { return this.date; } }
        public Customer CustomerData { get { return this.customerData; } }
    }
}
