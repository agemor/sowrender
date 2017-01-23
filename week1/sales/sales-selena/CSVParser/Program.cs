using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSVParser
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 해당 경로의 파일 읽어 text(string)에 저장 */
            string text = File.ReadAllText(@"D:\workplace\c#\sowrender\sample_revenue.csv", Encoding.UTF8);

            List<SalesRowData> salesRowDataList = new List<SalesRowData>(1500);

            string[] lines = text.Split('\n');


            for (int index = 1; index < lines.Length; index++)
            {
                string[] chunks = lines[index].Split(',');

                /* 비정상적으로 나누어진 customerName 합치기 */
                if (chunks.Length > 19)
                {
                    chunks[5] = chunks[5] + ", " + chunks[6];

                    for (int i = 6; i < chunks.Length - 1; i++)
                    {
                        chunks[i] = chunks[i + 1];
                    }

                    chunks[5] = chunks[5].Substring(1, chunks[5].Length - 2);
                }

                SalesRowData salesRowData = new SalesRowData();

                /* 값 저장하기 */
                try
                {
                    salesRowData.rowId = uint.Parse(chunks[0]);
                    salesRowData.amountUntaxed = double.Parse(chunks[1]);
                    salesRowData.amountUsd = double.Parse(chunks[2]);
                    salesRowData.company = chunks[3];
                    salesRowData.countryName = chunks[4];
                    salesRowData.customerName = chunks[5];
                    salesRowData.dateMonth = uint.Parse(chunks[6]);
                    salesRowData.dateOrder = new CSVParser.Date(chunks[7]);
                    salesRowData.dateShipped = new CSVParser.Date(chunks[8]);
                    salesRowData.discount = uint.Parse(chunks[9]);
                    salesRowData.exchangeRate = uint.Parse(chunks[10]);
                    salesRowData.model = chunks[11];
                    salesRowData.orderNumber = chunks[12];
                    salesRowData.priceUnit = double.Parse(chunks[13]);
                    salesRowData.productId = uint.Parse(chunks[14]);
                    salesRowData.productName = chunks[15];
                    salesRowData.qty = uint.Parse(chunks[16]);
                    salesRowData.status = chunks[17];
                    salesRowData.zip = chunks[18];

                    salesRowDataList.Add(salesRowData);
                }
                catch
                {
                    Console.WriteLine(index + " error");
                }

            }

            SumResult[] sumResultArray = new SumResult[20];

            /* sumResultArray 초기화 */
            for (int i = 0; i < sumResultArray.Length; i++)
            {
                sumResultArray[i] = new SumResult();
            }

            for (int i = 0; i < salesRowDataList.Count; i++)
            {
                int arrayIndex = 0;
                /* sumResultArray에 모델 명과 일치하는 데이터일 경우와 아예 추가되지 않은 경우까지 인덱스 증가 */
                for (; !sumResultArray[arrayIndex].model.Equals(""); arrayIndex++)
                {
                    if (sumResultArray[arrayIndex].model.Equals(salesRowDataList[i].model))
                        break;
                }

                sumResultArray[arrayIndex].model = salesRowDataList[i].model;
                sumResultArray[arrayIndex].amountUsd += salesRowDataList[i].amountUsd;
                sumResultArray[arrayIndex].qty += salesRowDataList[i].qty;

                /* 2014년도에 판매한 제품일 경우 */
                if (salesRowDataList[i].dateShipped.getYear() == 14)
                {
                    sumResultArray[arrayIndex]._14Sales += salesRowDataList[i].amountUsd;
                }
                /* 2015년도에 판매한 제품일 경우 */
                else if (salesRowDataList[i].dateShipped.getYear() == 15)
                {
                    sumResultArray[arrayIndex]._15Sales += salesRowDataList[i].amountUsd;
                }
            }

            /* print문 */
            for (int i = 0; sumResultArray[i].model != ""; i++)
            {
                Console.WriteLine(sumResultArray[i].model + "\n");
                Console.WriteLine("총 매출\t\t: " + "$" + String.Format("{0:0,0}", sumResultArray[i].amountUsd));
                if (sumResultArray[i]._14Sales == 0)
                    Console.WriteLine("14년도 매출\t: -");
                else
                    Console.WriteLine("14년도 매출\t: " + "$" + String.Format("{0:0,0}", sumResultArray[i]._14Sales));
                Console.WriteLine("15년도 매출\t: " + "$" + String.Format("{0:0,0}", sumResultArray[i]._15Sales));
                Console.WriteLine("평균 단가\t: " + "$" + String.Format("{0:0,0}", sumResultArray[i].amountUsd / sumResultArray[i].qty));
                Console.WriteLine("판매 수량\t: " + sumResultArray[i].qty + "\n");
            }
            
        }

        private static string addCommas(double data)
        {
            string temp = data.ToString(), result = "";
            int tempNumber;
            bool isDecimal = false;

            /* 들어온 숫자가 소수인지 판별. */
            isDecimal = int.TryParse(temp, out tempNumber);

            /* [0]은 정수, [1]은 소수 */
            string[] numberToString = temp.Split('.');

            temp = "";
            string num1ToString = numberToString[0];

            /* 정수 부분 string을 뒤집어 3개 단위로 ,(comma) 넣어주기 */
            for (int index1 = num1ToString.Length - 1, index2 = 0; index1 >= 0; index1--)
            {
                temp += num1ToString[index1];

                index2++;
                if (index2 % 3 == 0 && index2 != num1ToString.Length)
                    temp += ",";
            }

            /* string  다시 뒤집기 */
            for (int index1 = temp.Length - 1; index1 >= 0; index1--)
            {
                result += temp[index1];
            }

            /* 들어온 숫자가 소수인 경우, 소수점 자리 추가 */
            if (!isDecimal)
                result += "." + numberToString[1];

            return result;
        }


    }
}