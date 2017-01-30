using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurenderTycoonErica
{
    class CustomerManager
    {
        private static CustomerManager _instance;

        /* 전체 손님 정보 */
        private Dictionary<string, Customer> customerData;
        public Dictionary<string, Customer> CustomerData { get { return this.customerData; } }

        /* 싱글톤은 생성자로 생성하지 않음 */
        protected CustomerManager() { }

        /* 싱글톤 */
        static public CustomerManager GetInstance()
        {
            if(_instance == null)
            {
                _instance = new CustomerManager();
            }
            return _instance;
        }

        /* 새로운 손님이 왔을 때 손님 정보 저장 */
        public void AddCustomerData(Customer c)
        {
            if(c.PhoneNumber != null)
                customerData.Add(c.PhoneNumber, c);
        }

        /* 손님 정보 수정 */
        private void Modify(string phone, Customer c)
        {
            /* 손님정보가 있을 때만 수정 */
            if (customerData.ContainsKey(phone))
            {
                customerData[phone] = c;
            }
        }

        /* 손님 정보 삭제 */
        public void DeleteCustomerData(string phone)
        {
            /* 손님정보가 있을 때만 삭제 */
            if (customerData.ContainsKey(phone))
            {
                customerData.Remove(phone);
            }
        }
    }
}
