using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AurenderTycoonSelena
{
    class ClientManager
    {
        /* 싱글톤 */
        //-------------------------------------------------------
        private static ClientManager _instance;

        protected ClientManager() { }

        public static ClientManager GetInstance()
        {
            /* 한 번도 생성 안된 경우 생성 */
            if (_instance == null)
            {
                _instance = new ClientManager();
            }

            return _instance;
        }
        //-------------------------------------------------------

        public static uint ClientNumber = 1;

        DBManager mDBManager = DBManager.GetInstance();
        private ClientInfo[] clientArray;

        //0
        public void StoreClientDataFromDB()
        {
            int rowCountNum = mDBManager.GetRowCount("sowrender_client");

            /* 저장된 데이터가 하나도 없는 경우 */
            if (rowCountNum == 0)
            {
                clientArray = new ClientInfo[500];

                for (int i = 0; i < clientArray.Length; i++)
                {
                    clientArray[i] = new ClientInfo();
                }

                return;
            }

            string[] columns = new string[] { "client_number", "client_name", "client_phone", "client_address" };
            string[] data = mDBManager.SelectFromTable("sowrender_client", "select * from sowrender_client;", columns);
            clientArray = new ClientInfo[data.Length + 500];

            for (int i = 0; i < data.Length; i++)
            {
                clientArray[i] = new ClientInfo(data[i]);
            }

            /* 데이터를 insert할 때 대비해 DB에서 client_number 칼럼의 가장 끝값을 가져와 C를 날리고, 숫자만 저장*/
            string strTmp = Regex.Replace(clientArray[data.Length - 1].ClientNumber, @"\D", "");
            ClientNumber = uint.Parse(strTmp) + 1;
        }

        /* 구매가 성공적으로 일어난 경우  */
        public void SaveClientInfo(string name, string phone, string address)
        {
            if (ClientNumber == 1)
                clientArray[ClientNumber - 1] = new ClientInfo(name, phone, address);
            else
            {
                bool isExist = false;
                for (int i = 0; i < clientArray.Length; i++)
                {
                    if (clientArray[i].PhoneNumber.Equals(phone))
                    {
                        isExist = true; break;
                    }
                }

                if (isExist)
                {
                    clientArray[ClientNumber - 1] = new ClientInfo(name, phone, address);
                }
            }
        }

        /**/
        public ClientInfo[] GetClientInfoArray()
        {
            return clientArray;
        }
    }
}
