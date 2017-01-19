using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    
    class SalesRowData
    {
        /* 고유 값 */
        public uint rowId;

        /* 가격 */
        public double amountUntaxed;
        public double amountUsd;

        /* 회사 */
        public string company;

        /* 고객 정보 */
        public string countryName;
        public string customerName;

        public uint dateMonth;

        public Date dateOrder;
        public Date dateShipped;

        public uint discount;

        public uint exchangeRate;

        public string model;

        public string orderNumber;

        public double priceUnit;

        public uint productId;

        public string productName;

        /* 물품 수량 */
        public uint qty;

        public string status;

        public string zip;
    }
}
