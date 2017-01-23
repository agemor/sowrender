using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csvParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"D:\C# Project\csvParser\sample_revenue (1).csv", Encoding.UTF8);
            string[] lines = text.Split('\n');

            /* csv모든 데이터를 저장하는 변수 */
            List<SalesRowData> salesRowData = new List<SalesRowData>();
            salesRowData = SalesRowData.SaveCSVData(lines);

            /* 모델별 통계 */
            var mapAllYear = new Dictionary<string, Statistics>();
            var map2014 = new Dictionary<string, Statistics>();
            var map2015 = new Dictionary<string, Statistics>();

            mapAllYear = SalesRowData.Bind(salesRowData);
            map2014 = SalesRowData.Bind(salesRowData, 2014);
            map2015 = SalesRowData.Bind(salesRowData, 2015);

            String input;
            int key = 0;
            do
            {
                Console.WriteLine("보고 싶은 것의 인덱스를 입력해주세요");
                Console.WriteLine("1. 제품별 데이터");
                Console.WriteLine("2. 2014년 제품별 데이터");
                Console.WriteLine("3. 2015년 제품별 데이터");
                Console.WriteLine("0. 종료");

                input = Console.ReadLine();
                int.TryParse(input, out key);
                Console.Clear();

                if (key == 1)
                {
                    SalesRowData.PrintMap(mapAllYear, "제품별 데이터");
                }
                else if (key == 2)
                {
                    SalesRowData.PrintMap(map2014, "2014년 제품별 데이터");

                }
                else if (key == 3)
                {
                    SalesRowData.PrintMap(map2015, "2015년 제품별 데이터");
                }

                Console.ReadLine();
                Console.Clear();

            } while (0 != key);
        }
    }
}
