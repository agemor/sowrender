using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurenderTycoonErica
{
    class ProductStatistics
    {
        /* 싱글톤 */
        static protected ProductStatistics _instance;

        /* 자본금 */
        private int capital = 1000000000;

        ///* 모델별 통계 */
        //private Dictionary<string, SalesManager> salesAmoungByModel;

        ///* 전체 판매량 */
        //private List<> toalSalesAmount;

        /*싱글톤이므로 생성자 보호*/
        protected ProductStatistics() { }

        /* 싱글톤 */
        static public ProductStatistics GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductStatistics();
            }
            return _instance;
        }

        /* CSV파일로 출력 */
        public void ExportRecieptAsCSV()
        {
            List<Reciept> reciept = SalesManager.GetInstance().Reciept;
            using (System.IO.StreamWriter file =
    new System.IO.StreamWriter(@"C:\Users\dsm2015\Desktop\소렌더\sowrender\week2\aurender-tycoon\aurender-tycoon-erica\reciept.csv",false,Encoding.UTF8))
            {
                string line = "Date,model,color,capacity,price,amount,\"customerName\", \"customerPhoneNumber\"";
                file.WriteLine(line);
                line = "";
                
                for (int i = 0; i < reciept.Count(); i++)
                {
                    Console.WriteLine(reciept[i].Date.ToString());
                    line += AddQuotationMark(reciept[i].Date.ToString()) + ",";
                    line += AddQuotationMark(reciept[i].ModelName) + ",";
                    line += AddQuotationMark(reciept[i].ModelColor) + ",";
                    line += AddQuotationMark(reciept[i].Capacity) + ",";
                    line += AddQuotationMark(reciept[i].Price.ToString()) + ",";
                    line += AddQuotationMark(reciept[i].Amount.ToString()) + ",";
                    line += AddQuotationMark(reciept[i].CustomerData.Name) + ",";
                    line += AddQuotationMark(reciept[i].CustomerData.PhoneNumber) + ",\n";

                }
                file.Write(line);
            }
        }

        /* csv파일로 출력할 때 띄어쓰기가 있으면 큰따옴표 추가 */
        private string AddQuotationMark(string str)
        {
            if (str.Contains(" "))
            {
                return "\"" + str + "\"";
            }
            return str;
        }
    }
}
