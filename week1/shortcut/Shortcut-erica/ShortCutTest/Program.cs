using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShortCutTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string[] inputCut = new string[2];
            int n, d;
            int[][] data = new int[10010][];

            input = Console.ReadLine();
            inputCut = input.Split(' ');
            n = int.Parse(inputCut[0]);
            d = int.Parse(inputCut[1]);

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                int[] tmp = new int[] { int.Parse(strArr[0]), int.Parse(strArr[1]), int.Parse(strArr[2]) };
                for (int j = 0; j < 3; j++)
                {
                    data[i] = tmp;
                }

            }
            Console.Write(Shortcut.shortcut(n, d, data).ToString());
        }

        public class Shortcut
        {
            public static int shortcut(int N, int D, int[][] array)
            {
                int[] data = new int[10010];
                for (int i = 0; i <= D; i++)
                {
                    data[i] = i;
                }

                // array배열을 0번째 인덱스를 기준으로 정렬
                twoDimensionalArraySort(N, array);

                for (int i = 0; i < N; i++)
                {
                    int start = array[i][0];
                    int end = array[i][1];
                    int distance = array[i][2];

                    if (data[end] > distance)
                    {
                        for (int j = end; j <= D; j++)
                        {
                            if(data[j] > data[start] + distance + (j - end))
                            {
                                data[j] = data[start] + distance + (j - end);
                            }
                        }
                    }
                }

                return data[D];
            }

            //2차원 배열을 array[][0]을 기준으로 정렬
            static int[][] twoDimensionalArraySort(int n, int[][] array)
            {
                int standardIndex = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j][standardIndex] > array[j + 1][standardIndex])
                        {
                            int[] tmp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = tmp;
                        }
                        else if (array[j][standardIndex] == array[j + 1][standardIndex] &&
                            array[j][1] > array[j + 1][1])
                        {
                            int[] tmp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = tmp;
                        }
                    }
                }

                return array;
            }

        }


    }
}
