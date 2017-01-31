using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class Program
    {
        /**
         * 프로그램이 종료될 때 디비를 업데이트 하고싶은데 어떻게 해야할까?
         * 종료하는 절차 과정이 있다면 함수로 구현하면 되지만, 비정상적인 종료가 있을 경우
         * db에 업데이트 되지 않는 에러가 발생하게 된다.
         * 
         */
 
        static void Main(string[] args)
        {
            DBConnector dbConnector = new DBConnector();
            dbConnector.Connect();

            DBManager dbManager = new DBManager();
            //dbManager.SelectFromTable("select * from sowrender_client;");
           

            //dbManager.SelectFromTable("sowrender_client", "");
        }
    }
}
