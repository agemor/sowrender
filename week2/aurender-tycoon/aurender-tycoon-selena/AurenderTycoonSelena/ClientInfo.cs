using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    /* 고객 정보 저장 */
    class ClientInfo
    {
        public string ClientNumber;
        public string Name;
        public string PhoneNumber;
        public string ShippingAddress;

        /* 생성자 */
        public ClientInfo() { }
        public ClientInfo(string[] data)
        {
            this.ClientNumber = data[0];
            this.Name = data[1];
            this.PhoneNumber = data[2];
            this.ShippingAddress = data[3];
        }

        public ClientInfo(string dbData)
        {
            string[] data = dbData.Split(',');

            this.ClientNumber = data[0];
            this.Name = data[1];
            this.PhoneNumber = data[2];
            this.ShippingAddress = data[3];
        }

        public ClientInfo(string name, string phone, string address)
        {
            this.ClientNumber = "C" + ClientManager.ClientNumber;
            this.Name = name;
            this.PhoneNumber = phone;
            this.ShippingAddress = address;
        }
    }
}
