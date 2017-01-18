using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shortcut_selena;

namespace shortcut_selena
{
    class Program
    {

        private static ShortCut[] shortCutArr;
        private static int distance;
        private static int SCCount; // SC = shortcut

        static void Main(string[] args)
        {
            setValues();
            sortList();
        }

        static void setValues() {
            string inputData;
            string[] tmpArray = new string[2];

            inputData = Console.ReadLine();
            tmpArray = inputData.Split(' ');

            SCCount = int.Parse(tmpArray[0]);
            distance = int.Parse(tmpArray[1]);

            shortCutArr = new ShortCut[SCCount];

            for (int index = 0; index < SCCount; index++)
            {
                inputData = Console.ReadLine();
                tmpArray = inputData.Split(' ');

                shortCutArr[index] = new ShortCut(int.Parse(tmpArray[0]), int.Parse(tmpArray[1]), int.Parse(tmpArray[2]));
            }
        }

        static void sortList()
        {
            QuickSort quick = new QuickSort();
            quick.sort(shortCutArr, 0, shortCutArr.Length - 1);
        }

        static void calculate()
        {

        }
    }
}
