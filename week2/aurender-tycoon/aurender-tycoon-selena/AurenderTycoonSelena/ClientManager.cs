using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class ClientManager
    {

        // dbmanager 불러와서 고객 정보 저장


        private DBManager dbManager = new DBManager();
        //dbManager.createDb(parameter);

        public void saveClientInfo()
        {

        }

        public void getClientInfo(string clientName)
        {
            //db에 접근해서 clientName을 key로 데이터 가져오기

            //todo: 중복 처리
        }
    }
}
