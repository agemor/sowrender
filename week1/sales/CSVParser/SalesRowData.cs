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
        public string country_name;
        public string customer_name;

        public uint date_month;

        public Date date_order;
        public Date date_shipped;

        public uint discount;

        public uint exchange_rate;

        public string model;

        public string order_number;

        public double price_unit;

        public uint product_id;

        public string product_name;

        /* 물품 수량 */
        public uint qty;

        public string status;

        public string zip;
    }
}
