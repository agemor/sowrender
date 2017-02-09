using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using static System.Linq.Enumerable;

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
        public DateTime dateOrder;
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

        /* 멤버변수를 초기화해주는 함수
         * 성공하면 true, 실패하면 false를 반환 */
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

        static public List<SalesRowData> SaveCSVData(string[] lines)
        {
            /* csv모든 데이터를 저장하는 변수 */
            List<SalesRowData> salesRowData = new List<SalesRowData>();

            /* csv파일을 정리하여 salesRowData에 저장 */
            for (int i = 1; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                if (tmp.Length > 19)
                {
                    tmp[5] = tmp[5] + ',' + tmp[6];
                    for (int j = 6; j < tmp.Length - 1; j++)
                    {
                        tmp[j] = tmp[j + 1];
                    }
                    tmp[tmp.Length - 1] = null;
                    tmp[5] = tmp[5].Substring(1, tmp[5].Length - 2);
                }

                SalesRowData newRowData = new SalesRowData();

                /* setData가 성공할 때만 추가*/
                if (newRowData.SetData(tmp))
                {
                    salesRowData.Add(newRowData);
                }

            }
            return salesRowData;
        }

        /* List<SalesRowData>를 정렬해주는 함수 
           desCendingOrder은 내림차순이면 true, 오름차순이면 false */
        public List<SalesRowData> CsvSort(List<SalesRowData> salesRowData, bool desCendingOrder = true)
        {
            int deCendingOrderCheck = 1;
            if (desCendingOrder)
            {
                deCendingOrderCheck = -1;
            }

            salesRowData.Sort(delegate (SalesRowData row1, SalesRowData row2)
            {
                return row1.amountUntaxed.CompareTo(row2.amountUntaxed) * deCendingOrderCheck;
            });

            return salesRowData;
        }

        public Dictionary<string, Statistics> mapSort(Dictionary<string, Statistics> input, bool desCendingOrder = true)
        {
            int deCendingOrderCheck = 1;
            if (desCendingOrder)
            {
                deCendingOrderCheck = -1;
            }

            List<KeyValuePair<string, Statistics>> myList = new List<KeyValuePair<string, Statistics>>(input);
            myList.Sort(
                delegate (KeyValuePair<string, Statistics> pair1,
                KeyValuePair<string, Statistics> pair2)
                {
                    return pair1.Value.amountUsd.CompareTo(pair2.Value.amountUsd);
                }
            );
            return input;
        }


        static public bool YearCheck(int year, SalesRowData s)
        {
            return s.dateOrder.Year == year;
        }

        /* 모델별 통계 */
        static public Dictionary<String, Statistics> Bind(List<SalesRowData> s, int year = -1)
        {
            var map = new Dictionary<String, Statistics>();
            Statistics statistics = new Statistics();
            for (int i = 0; i < s.Count; i++)
            {
                if (year == -1 || year == s[i].dateShipped.Year)
                {
                    if (!map.ContainsKey(s[i].model))
                    {
                        map.Add(s[i].model, new Statistics());
                    }
                    map[s[i].model].qty += s[i].qty;
                    map[s[i].model].amountUsd += s[i].amountUsd;

                    //statistics.qty = s[i].qty;
                    //statistics.amountUsd = s[i].amountUsd;
                    //map[s[i].model] += statistics; 왜 안되지??????????
                }

            }

            /* 평균 단가 */
            for (int i = 0; i < map.Count; i++)
            {
                map.ElementAt(i).Value.unitPriceAverage = map.ElementAt(i).Value.amountUsd / (double)map.ElementAt(i).Value.qty;
            }

            return map;
        }

        /* 숫자사이에 ','를 추가 */
        static public string AddCommas(double number)
        {
            string rawNum = number.ToString();
            string[] division;
            string sDecimal = "";
            string sInteger = "";

            division = rawNum.Split('.');
            sInteger = division[0];
            if (division.Length == 2)
            {
                sDecimal = "." + division[1];
            }

            int n = sInteger.Length;
            while (n > 3)
            {
                n -= 3;
                sInteger = sInteger.Insert(n, ",");
            }

            return sInteger + sDecimal;


        }

        static public void PrintMap(Dictionary<string, Statistics> map, string explanation = "")
        {
            Console.WriteLine(explanation);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("{0,18} {1,10} {2,10}", "수량", "총 매출액", "평균단가");
            for (int i = 0; i < map.Count; i++)
            {
                Console.Write("{0,15}", map.ElementAt(i).Key + " : ");
                Console.WriteLine("{0,5} \t  $ {1,-13:0,0} $ {2,-13:0,0}", map.ElementAt(i).Value.qty,
                                  map.ElementAt(i).Value.amountUsd,
                                  map.ElementAt(i).Value.unitPriceAverage);
            }
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Enter을 누르면 메뉴로 넘어갑니다.");

        }


    }
}