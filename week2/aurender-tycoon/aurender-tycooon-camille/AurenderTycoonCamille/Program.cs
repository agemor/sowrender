using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoon
{
    /**
     * This class contain main funtion
     */
    class Program
    {
        static void Main(string[] args)
        {
            string purchaseOrder;
            int num;
            Console.Write("다녀갈 손님의 수를 입력하세요 : ");
            num = Console.Read();
            DBManager dbmanager = new DBManager();
            
            for (int i = 0; i < num; i++)
            {
                /*이름, 구매하고 싶은 기기, 수량, 배송지, 연락처*/
                Console.WriteLine("\"이름, 구매할 기기, 색상, 용량, 수량, 배송지, 연락처\"를 입력하세요");
                purchaseOrder = Console.ReadLine();
                GetKeyword(purchaseOrder);
            }
        }

        /* get keyword in order string */
        static void GetKeyword(string order)
        {
            order = order.Replace(" ", "");
            order = order.Replace("(", ",");
            order = order.Replace(")", "");
            string[] keyword = order.Split(',');

            if (keyword.Length != 7)
            {
                Console.WriteLine("보기의 형식을 따라 다시 입력하세요");
            }
            else
            {
                //match each keyword
            }
        }
    }
}
