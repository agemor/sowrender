using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace csvParser
{
    class SalesRowData
    {
        /* 세일즈 데이터 id*/
        public uint rowId;

        /* 비용 */
        public double amountUntaxed;
        public double amountUsd;

        /* 회사 */
        public string company;

        public string countryName;
        public string customerName;

        public int dateMonth;
        public DateTime dateOrder; //Toddo
        public DateTime dateShipped;

        public uint discount;
        public uint exchange;
        public string model;
        public string orderNum;
        public double priceUnit;
        public int productId;
        public string productName;
        public int qty;
        public string status;
        public string zip;

        /* 멤버변수를 초기화해주는 함수 */
        public bool setData(string[] input)
        {
            try
            {
                rowId = uint.Parse(input[0]);
                amountUntaxed = double.Parse(input[1]);
                amountUsd = double.Parse(input[2]);
                company = input[3];
                countryName = input[4];
                customerName = input[5];
                dateMonth = int.Parse(input[6]);
                if (DateTime.TryParseExact(input[7], "MM-dd-yy", null,
                                      DateTimeStyles.None, out dateOrder))
                {
                    Console.WriteLine("Date(dateOrder) 형식 오류");
                }
                if (DateTime.TryParseExact(input[8], "MM-dd-yy", null,
                                      DateTimeStyles.None, out dateShipped))
                {
                    Console.WriteLine("Date(dateShipped) 형식 오류");

                }

                discount = uint.Parse(input[9]);
                exchange = uint.Parse(input[10]);
                model = input[11];
                orderNum = input[12];
                priceUnit = double.Parse(input[13]);
                productId = int.Parse(input[14]);
                productName = input[15];
                qty = int.Parse(input[16]);
                status = input[17];
                zip = input[18];

                Console.WriteLine(rowId.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
