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
        public bool SetData(string[] input)
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
                if (!DateTime.TryParseExact(input[7], "M/d/yy", null,
                                      DateTimeStyles.None, out dateOrder))
                {
                    Console.WriteLine("Date(dateOrder) 형식 오류");
                }
                if (!DateTime.TryParseExact(input[8], "M/d/yy", null,
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
                
                return true;
            }
            catch /* Data가 잘못들어간 경우는 처리x */
            {
                return false;
            }
        }

        /* List<SalesRowData>을 정렬한 후, year에 맞는 데이터만 뽑음*/
        //public List<SalesRowData> CsvSort(int year, List<SalesRowData> salesRowData, bool DesCendingOrder = true)
        //{
        //    List<SalesRowData> result = new List<SalesRowData>();
        //    result = CsvSort(sale)

        //}
        /* List<SalesRowData>를 정렬해주는 함수 
           desCendingOrder은 내림차순이면 true, 오름차순이면 false */

        public List<SalesRowData> CsvSort(List<SalesRowData> salesRowData , bool desCendingOrder = true)
        {
            int deCendingOrderCheck = 1;
            if(desCendingOrder)
            {
                deCendingOrderCheck = -1;
            }

            salesRowData.Sort(delegate (SalesRowData row1, SalesRowData row2)
            {
                return row1.amountUntaxed.CompareTo(row2.amountUntaxed) * deCendingOrderCheck;
            });

            return salesRowData;
        }

        static public bool YearCheck(int year, SalesRowData s)
        {
            return s.dateOrder.Year == year;
        }
        
        static public Dictionary<String ,double> bind(List<SalesRowData> s, int year=-1)
        {
            var map = new Dictionary<String, double>();
            for(int i=0; i<s.Count; i++)
            {
                if(year==-1 || year == s[i].dateShipped.Year)
                {
                    if (!map.ContainsKey(s[i].model))
                    {
                        map.Add(s[i].model, 0);
                    }
                    map[s[i].model] += s[i].amountUsd;
                }
               
            }
            return map;
        }

        static public string addCommas(double number)
        {
            string rawNum = number.ToString();
            string[] division;
            string sDecimal = "";
            string sInteger = "";

            division = rawNum.Split('.');
            sInteger = division[0];
            if(division.Length == 2)
            {
                sDecimal = "." + division[1];
            }

            int n = sInteger.Length  ;
            while( n > 3 )
            {
                n -= 3;
                sInteger = sInteger.Insert(n,",");
            }

            return sInteger + sDecimal;


        }
      

    }
}
