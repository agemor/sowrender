using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class ReceiptManager
    {
        ReceiptData[] receiptArray = new ReceiptData[99999999/*row 개수 가져왔음 좋겠다 ㅋㅋ */];

        public void AddReceiptFromDb( ) {
            //모든 구매가 끝났을 경우, db로 전송
        }

        public void DeleteReceiptFromDb(string orderNumber) {
            //refund 함수가 실행됐을 경우 orderNumber로 select한 후, 해당 row 삭제하기
        }

        public void PrintReceipt(string orderNumber)
        {
            int index = 0;
            for(; index < receiptArray.Length; index++)
            {
                if (receiptArray[index].orderNumber.Equals(orderNumber))
                    break;
            }

            ReceiptData receipt = new ReceiptData();

            receipt.orderNumber = receiptArray[index].orderNumber;
            receipt.purchasedModel = receiptArray[index].purchasedModel;
            receipt.clientNumber = receiptArray[index].clientNumber;

            //receipt 프린트시키기.
        }
    }
}
