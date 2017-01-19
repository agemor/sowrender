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
                //for(int j=0; j<tmp.Length; j++)
                //{
                //    Console.WriteLine("*"+tmp[j]);
                //}
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
                if (newRowData.setData(tmp))
                {
                    salesRowData.Add(newRowData);
                }
            }

            for (int i = 0; i < salesRowData.Count; i++)
            {
                Console.WriteLine(salesRowData[i].rowId);
            }

            Console.ReadKey();

        }

    }
}
