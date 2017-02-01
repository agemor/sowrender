using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class ReceiptData
    {
        /* 주문 번호, 고객 번호, 구매한 모델*/
        public string OrderNumber; // primaryKey(unique)
        public string ClientNumber;
        public string PurchasedModel;
        public uint Quantity;

        /* 생성자 */
        public ReceiptData()
        {

        }
        public ReceiptData(string cn, string pm, uint quantity)
        {
            this.OrderNumber = "O" + ReceiptManager.OrderNumber;
            this.ClientNumber = cn;
            /* ex) PurchasedModel = "model,color,storage" */
            this.PurchasedModel = pm;
            this.Quantity = quantity;
        }
        public ReceiptData(string dbData)
        {
            string[] data = dbData.Split(',');

            this.OrderNumber = data[0];
            this.ClientNumber = data[1];
            this.PurchasedModel = data[2];
            this.Quantity = uint.Parse(data[3]);
        }
    }
}
