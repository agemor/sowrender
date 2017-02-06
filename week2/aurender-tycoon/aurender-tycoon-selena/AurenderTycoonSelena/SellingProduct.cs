using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class SellingProduct
    {
        private string[] data;

        private ClientInfo client;
        private ReceiptData receipt;

        /* 데이터 가공하기 */
        /* Data parameter example : 이름,구매하고 싶은 기기(색깔, 용량), 수량, 배송지, 연락처 */
        public int ManufactureInputData(string inputData)
        {
            data = inputData.Split(new string[] { "), ", ", ", " (" }, StringSplitOptions.RemoveEmptyEntries);
            //0-고객 이름, 1-모델, 2-색깔, 3-용량, 4-재고, 5-배송지, 6-연락처

            client = new ClientInfo(data[0], data[6], data[5]);
            receipt = new ReceiptData();

            /* 재고 반환 */
            return int.Parse(data[4]);
        }
    
        /* 판매 과정 1번 - 실제로 데이터가 있는지 있다면 재고가 있는지 검사 */
        /* data parameter input example : model,color,storage */
        public void CheckAvailableData(ProductInfo[] p)
        {
            int index = 0;
            for(; index < data.Length; index++)
            {
                if(p[index].Model.Equals(data[1]) && p[index].Color.Equals(data[2]) 
                    && p[index].Storage.Equals(data[3]))
                {
                    break;
                }
            }

            if(p[index].Stock > int.Parse(data[4]))
                SellProduct();
        }

        /* 환불 */
        public void RefundProduct()
        {
            /**
             * 고객의 정보(핸드폰 번호로 검색)해서 있는지 확인 (F -> return;)
             * 있으면, 해당 배열의 client_number 가져오기
             * receipt_table에서 cluent_number로 검색해서 가져오기 (F-> return;)
             * 있으면, 구매한 수량(Quantity)와 반품하려는 개수 확인
             * 반품하려는 개수가 많으면 구매한 수량만큼만 환불
             * 구매한 수량이 많으면 그냥 진행.
             *  
             * 환불이 정상적으로 진행하면, receipt_table 가서 해당 order_number 날려버리기 ^^ 
             */
        }

        public void SellProduct()
        {
            bool isSuccess = false;

            ProductManager mProductManager = ProductManager.GetInstance();
            isSuccess = mProductManager.ManageStock(data[1], data[2], data[3], int.Parse(data[4]));

            if (isSuccess)
            {
                ClientManager mClientManager = ClientManager.GetInstance();
                mClientManager.SaveClientInfo(data[0], data[6], data[5]);

                ReceiptManager mReceiptManager = ReceiptManager.GetInstance();
                mReceiptManager.SaveReceipt("C" + ClientManager.ClientNumber, data[1] + "," + data[2] + "," + data[3], uint.Parse(data[4]));


            }
        }
        

    }
}
