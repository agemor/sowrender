using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    /* 고객 정보 저장 */
    struct ClientInfo
    {
        public string clientNumber;
        public string name;
        public string phoneNumber;
        public string shippingAddress;

        public ClientInfo(string[] data)
        {
            this.clientNumber = data[0];
            this.name = data[1];
            this.phoneNumber = data[2];
            this.shippingAddress = data[3];
        }

        /*public ClientInfo(string name, string phoneNumber, string shippingAddress)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.shippingAddress = shippingAddress;
        }*/

        //--------------------------------------------------------------------------------

        /**
         * 모든 고객 데이터 저장
         * 이 클래스가 호출 될 때 db에서 모든 고객 데이터를 읽어와 해당 배열에 저장
         */

        /*private string[] client_number; // unique key

        private string[] name;
        private string[] phone;
        private string[] address;*/
    }
}
