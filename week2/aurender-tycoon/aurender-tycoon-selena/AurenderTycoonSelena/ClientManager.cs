using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class ClientManager
    {
        ClientInfo[] clientArray = new ClientInfo[100/*row 개수 가져왔음 좋겠다.*/];
        // dbmanager 불러와서 고객 정보 저장

        public void Init()
        {
            for (int i = 0; i < clientArray.Length; i++)
                clientArray[i] = new ClientInfo();
        }


        private DBManager dbManager = new DBManager();

        public void saveClientInfo()
        {
            //구매가 성공적으로 끝날 경우 db로 클라이언트 정보 전송
        }

        public void getClientInfo(string clientNumber)
        {
            //db에 접근해서 clientNumber를 key로 데이터 가져오기
            string[] columns = new string[]{"client_number", "client_name", "client_phone", "purchased_model"};

            ClientInfo client = new ClientInfo(dbManager.SelectFromTable("sowrender_client", "select * from sowrender_client where client_number = " + clientNumber + ";", columns));
            
            //Console.WriteLine(client.clientNumber);
        }
    }
}
