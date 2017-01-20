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

            /* 모델별 통계 */
            var mapAllYear = new Dictionary<string, double>();
            var map2014 = new Dictionary<string, double>();
            var map2015 = new Dictionary<string, double>();

            mapAllYear = SalesRowData.Bind(salesRowData);
            map2014 = SalesRowData.Bind(salesRowData, 2014);
            map2015 = SalesRowData.Bind(salesRowData, 2015);

            Console.WriteLine("All------------------------------ ");
            for (int i = 0; i < mapAllYear.Count; i++)
            {
                Console.WriteLine(mapAllYear.ElementAt(i).Key + " : " + mapAllYear.ElementAt(i).Value);
            }

            Console.WriteLine("2014----------------------------------- ");
            for (int i = 0; i < map2014.Count; i++)
            {
                Console.WriteLine(map2014.ElementAt(i).Key + " : " + map2014.ElementAt(i).Value);
            }

            Console.WriteLine("2015---------------------------------- ");
            for (int i = 0; i < map2015.Count; i++)
            {
                Console.WriteLine(map2015.ElementAt(i).Key + " : " + map2015.ElementAt(i).Value);
            }

            Console.WriteLine(SalesRowData.AddCommas(4556256.5256));
            Console.ReadKey();
        }

    }
}
