using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurenderTycoonErica
{
    class Customer
    {
        /* 손님 이름, 전화번호, 배송지 */
        private string name;
        private string phoneNumber;
        private string shippingAddress;

        /* 주문횟수 */
        private int count = 0;

        /* get을 이용해 얻기 가능 */
        public string Name { get { return this.name; } }
        public string PhoneNumber { get { return this.phoneNumber; } }
        public string ShippingAddress { get { return this.shippingAddress; } }
        public int Count
        {
            get { return this.count; }
            set
            {
                /* 주문횟수에 잘못된 값이 들어가지 않기 위함 */
                if (value >= 0)
                {
                    count = value;
                }
            }
        }

        /* 생성자 */
        public Customer() { }
        public Customer(string name, string phoneNumber, string shippingAddress, int count = 0)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.shippingAddress = shippingAddress;
            this.count = count;
        }

    }
}
