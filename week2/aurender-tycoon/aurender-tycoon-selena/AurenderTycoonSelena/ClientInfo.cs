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
        private string name;
        private string phoneNumber;
        private string shippingAddress;

        private string[] orderNumber;

        public ClientInfo(string name, string phoneNumber, string shippingAddress)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.shippingAddress = shippingAddress;
        }
    }
}
