using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AurenderTycoonSelena
{
    class ReceiptManager
    {
        /* 싱글톤 */
        //-------------------------------------------------------
        private static ReceiptManager _instance;

        protected ReceiptManager() { }

        public static ReceiptManager GetInstance()
        {
            /* 한 번도 생성 안된 경우 생성 */
            if (_instance == null)
            {
                _instance = new ReceiptManager();
            }

            return _instance;
        }
        //-------------------------------------------------------

        /* 고유한 키  */
        public static uint OrderNumber = 1;

        DBManager mDBManager = DBManager.GetInstance();
        private ReceiptData[] receiptArray;

        //0
        public void StoreReceiptDataFromDB()
        {
            int rowCountNum = mDBManager.GetRowCount("sowrender_receipt");

            /* 저장된 데이터가 하나도 없는 경우 */
            if (rowCountNum == 0)
            {
                receiptArray = new ReceiptData[500];

                for (int i = 0; i < receiptArray.Length; i++)
                {
                    receiptArray[i] = new ReceiptData();
                }

                return;
            }

            string[] columns = new string[] { "order_number", "client_number", "purchased_model", "quantity" };
            string[] data = mDBManager.SelectFromTable("sowrender_receipt", "select * from sowrender_receipt;", columns);
            receiptArray = new ReceiptData[data.Length + 500];

            for (int i = 0; i < data.Length; i++)
            {
                receiptArray[i] = new ReceiptData(data[i]);
            }

            /* 데이터를 insert할 때 대비해 DB에서 order_number 칼럼의 가장 끝값을 가져와 C를 날리고, 숫자만 저장*/
            string strTmp = Regex.Replace(receiptArray[data.Length - 1].OrderNumber, @"\D", "");
            OrderNumber = uint.Parse(strTmp) + 1;

        }

        public void SaveReceipt(string cm, string pm, uint quantity)
        {
            ReceiptData receipt = new ReceiptData(cm, pm, quantity);

            receiptArray[OrderNumber - 1] = receipt;

            /* 한 차례의 구매 과정이 끝날 때마다, 1씩 더하기 */
            OrderNumber += 1;
            ClientManager.ClientNumber += 1;
        }

        public void AddReceiptToDb()
        {
            mDBManager.ExecuteQuery("인서트 코드");
        }

        public void DeleteReceiptFromDb(string orderNumber)
        {
            //환불이 일어날 경우, db로 전송
        }

        public void PrintReceipt(string orderNumber)
        {
            int index = 0;
            for (; index < receiptArray.Length; index++)
            {
                if (receiptArray[index].OrderNumber.Equals(orderNumber))
                    break;
            }

            ReceiptData receipt = new ReceiptData();

            receipt.OrderNumber = receiptArray[index].OrderNumber;
            receipt.PurchasedModel = receiptArray[index].PurchasedModel;
            receipt.ClientNumber = receiptArray[index].ClientNumber;

            //receipt 프린트시키기.
            //영수증에 출력시킬 데이터 : 구매자, 구매 물품(모델-색깔-용량), 수량, 가격, 토탈 금액 
        }

        public ReceiptData[] GetReceiptDataArray()
        {
            return receiptArray;
        }
    }
}
