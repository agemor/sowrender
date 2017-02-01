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
            DBManager mDBManager = DBManager.GetInstance();
            ClientManager mClientManager = ClientManager.GetInstance();
            ReceiptManager mReceiptManager = ReceiptManager.GetInstance();
            ProductManager mProductManager = ProductManager.GetInstance();
            SellingProduct sellingProduct = new SellingProduct();

            mDBManager.Connect("localhost", "sowrender", "selena", "selena");

            mClientManager.StoreClientDataFromDB();
            mReceiptManager.StoreReceiptDataFromDB();

            mProductManager.SetData();

            //mDBManager.ExecuteQuery("insert into sowrender_client values('c4', 'aa', '01', '1a');");
            //mClientManager.StoreClientDataFromDB();

            /* clientCount : 구매 고객의 수 */
            int clientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < clientCount; i++)
            {
                /* count : 고객이 입력한 데이터에서 수량을 반환*/
                int count = sellingProduct.ManufactureInputData(Console.ReadLine());


                /* count가 1 이상인 경우, 고객이 구매를 요청했을 때 */
                if (count > 0)
                {
                    sellingProduct.CheckAvailableData(mProductManager.GetProductData());
                }

                /* count가 -1 이하인 경우, 고객이 환불을 요청했을 때 */
                else if (count < 0)
                {
                    sellingProduct.RefundProduct();
                }

            }

        }
    }
}
