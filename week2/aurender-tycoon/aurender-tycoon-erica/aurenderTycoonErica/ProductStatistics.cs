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
    new System.IO.StreamWriter(@"C:\Users\dsm2015\Desktop\소렌더\sowrender\week2\aurender-tycoon\aurender-tycoon-erica\reciept.csv", false, Encoding.UTF8))
            {
                string line = "Date,model,color,capacity,price,amount,\"customerName\", \"customerPhoneNumber\"";
                file.WriteLine(line);
                line = "";

                for (int i = 0; i < reciept.Count(); i++)
                {
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

        /* 모델별 통계 */
        public Dictionary<String, Statistics> Bind(List<Reciept> s, int year = -1)
        {
            var map = new Dictionary<String, Statistics>();
            Statistics statistics = new Statistics();
            for (int i = 0; i < s.Count; i++)
            {
                string key = s[i].ModelName + s[i].ModelColor + s[i].Capacity;
                if (year == -1 || year == s[i].Date.Year)
                {
                    if (!map.ContainsKey(key))
                    {
                        map.Add(key, new Statistics(s[i].ModelName, s[i].ModelColor, s[i].Capacity));
                    }
                    map[key].amount += s[i].Amount;

                }

            }

            ProductManager pm = ProductManager.GetInstance();
            /* 매출(sales) 구함 */
            for (int i = 0; i < map.Count; i++)
            {
                string key = map.ElementAt(i).Value.modelName + map.ElementAt(i).Value.color + map.ElementAt(i).Value.capacity;
                if (pm.ProductInfo.ContainsKey(key))
                {
                    map.ElementAt(i).Value.sales = map.ElementAt(i).Value.amount * pm.ProductInfo[key].Price;
                }

            }
            return map;
        }
    }

    /* 단골손님 리스트 */
    /*public List<Customer> RegularCustomerList()
    {

    }*/
}
