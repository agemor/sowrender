using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CsvParser_Camille
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\dsm\Downloads\sample_revenue.csv", Encoding.UTF8);

            List<SalesRowData> salesRpwDataList = new List<SalesRowData>(200);
            List<string> chucks = new List<string>(200);

            String[] lines = text.Split('\n'); //개행으로 구분하여 한 줄씩 나눠서 얻기

            foreach(string line in lines)
            {
                chucks = line.Split(',').ToList();

                if (chucks.Count > 19)
                {
                    chucks[5] = chucks[5] + ',' + chucks[6];
                    chucks[5] = chucks[5].Replace('"', ' ');
                    chucks.Remove(chucks[6]);
                }
                SalesRowData salesRowData = new SalesRowData();

                uint.TryParse(chucks[0], out salesRowData.rowId);   // salesRowData.rowId = uint.Parse(chucks[0]);
                double.TryParse(chucks[1],out salesRowData.amountUntaxed);  //double.Parse(chucks[1]);    //Convert.ToDouble(chucks[1]);
                salesRowData.company = chucks[3];
                salesRowData.country = chucks[4];
                salesRowData.customer = chucks[5];
                //salesRowData.dateOrder = Convert.ToDateTime(chucks[7]);

                salesRpwDataList.Add(salesRowData);
                
                Console.WriteLine(chucks[5]);
            }
        }
    }
    /**         //class 주석 다는법
     * This class descirbes how we handle row data  //설명
     * 
     * @author WonJung Jeong    //제작자
     * @date                    //날짜
     */
    class SalesRowData
    {
        /* 세일즈 데이터 id */
        public uint rowId;
        public int dateShipped;
        public int discount;
        public int exchangeRate;
        public string model;
        public string orderNumber;
        public int priceUnit;
        public uint productId;
        public uint quantity;

        /* 세일즈 날짜 */
        public int dateMonth;
        public DateTime dateOrder;

        /* 가격 */
        public double amountUntaxed;

        /* 판매 회사 */
        public string company;
        public string customer;
        public string country;
        public string productName;
        public string status;
        public string zip;

        /*Getter and Setter pattern(for securitiy → private and change)
        public uint getRowId()
        {
            return this.rowId;
        }

        public void setRowId()
        {
            throw new Exception("You cannot edit this data");
        }*/
    
    }

}
