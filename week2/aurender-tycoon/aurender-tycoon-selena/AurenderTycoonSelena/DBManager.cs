using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class DBManager
    {

        //모든 구매 데이터 저장(영수증)
        public void saveReceipt(ReceiptData receipt)
        {
            //DB에 접근해서 receipt 가져와서 저장
        }

        public void returnCsvFile()
        {
            //DB에 있는 파일 다 빼서 CSV File 생성
        }

        //필요한 디비 생성
        public void createDb(string dbName, string[] type, string[] columName)
        {
            int index = 0; // 배열을 읽기 위한 index

            //쿼리문 작성
        }

        public void updateDb(string dbName)
        {

        }

        public void connectDb(string dbName)
        {

        }
    }
}
