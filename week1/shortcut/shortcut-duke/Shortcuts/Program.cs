using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortcuts
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] roadInfo = new int[2];
            int shortcutCount;
            int roadLength;

            Shortcut shortcut = new Shortcut();
            List<Shortcut> shortcutInfo = new List<Shortcut>();
            var findWay = new Dictionary<List<Shortcut>, WayLength>();

            ShortestWayFind finder = new ShortestWayFind();
            roadInfo = finder.RecieveInfo();
            shortcutCount = roadInfo[0];
            roadLength = roadInfo[1];

            shortcutInfo = finder.RecieveInfo(shortcutCount);

            shortcut.SortShortcuts(shortcutInfo);
            shortcut.PrintShortcuts(shortcutInfo);

            finder.FindWays(0, roadLength, shortcutInfo, findWay);
        }
    }

    interface Basic
    {
        void SortShortcuts(List<Shortcut> SortTarget);
        void PrintShortcuts(List<Shortcut> SortTarget);
    }
    class Shortcut : Basic
    {
        public int departPoint;
        public int arrivalPoint;
        public int shortcutLength;
        public Shortcut() { }
        public Shortcut(int DepartPoint, int ArrivalPoint, int ShortcutLength)
        {
            this.departPoint = DepartPoint;
            this.arrivalPoint = ArrivalPoint;
            this.shortcutLength = ShortcutLength;
        }
        public void SortShortcuts(List<Shortcut> sortTarget)
        {
            sortTarget.Sort(delegate (Shortcut Sc1, Shortcut Sc2)
            {
                return Sc1.departPoint.CompareTo(Sc2.departPoint);
            });
        }
        public void PrintShortcuts(List<Shortcut> sortTarget)
        {
            for (int i = 0; i < sortTarget.Count; i++)
            {
                Console.WriteLine("{0} {1} {2}", sortTarget[i].departPoint, sortTarget[i].arrivalPoint, sortTarget[i].shortcutLength);
            }
            Console.WriteLine();
        }
    }

    class WayLength
    {
        public int pointLength;
        public int totalLength;
    }

    interface Readable
    {
        int[] SplitInputString(int count, string input);
        int StringtoNum(string num);
    }
    interface ReceiveAble : Readable
    {
        int[] RecieveInfo();
        List<Shortcut> RecieveInfo(int Count);
    }
    interface ErrorResoluble
    {
        void CheckLessThanZeroMoreThanTenthousand(int value);
        void CheckWhileErrorInSplitInputString();
    }
    class ShortestWayFind : Readable, ReceiveAble, ErrorResoluble
    {
        public int[] RecieveInfo()
        {
            int[] roadInputArr = new int[2];
            string input;
            Console.WriteLine("Input Shortcut's count and Road's length");
            input = Console.ReadLine();
            roadInputArr = SplitInputString(2, input);
            return roadInputArr;
        }
        public List<Shortcut> RecieveInfo(int count)
        {
            List<Shortcut> shortcutInputArr = new List<Shortcut>();
            string input;
            int[] shortcutSaveTmp = new int[3];
            Console.WriteLine("Input Shortcut's depart point, arrival point, length");
            for (int i = 0; i < count; i++)
            {
                input = Console.ReadLine();
                shortcutSaveTmp = SplitInputString(3, input);
                shortcutInputArr.Add(new Shortcut(shortcutSaveTmp[0], shortcutSaveTmp[1], shortcutSaveTmp[2]));
            }
            return shortcutInputArr;
        }
        public int[] SplitInputString(int Count, string Input)
        {
            bool IsThatSpace = true;
            int SpaceCount = 0, WithoutSpace = 0;
            char Space = ' ';
            foreach (char c in Input)
            {
                if (Equals(c, Space))
                    SpaceCount++;
            }

            string[] SplitTmp = new string[SpaceCount + 1];
            int[] SplitResult = new int[Count];

            SplitTmp = (Input.Split(Space));
            for (int i = 0; i < Count; i++)
            {
                while (IsThatSpace)
                {
                    if (Equals(SplitTmp[WithoutSpace], ' '))
                    {
                        if (WithoutSpace <= SpaceCount)
                            WithoutSpace++;
                        else
                            CheckWhileErrorInSplitInputString();
                    }
                    else
                        IsThatSpace = false;
                }
                SplitResult[i] = StringtoNum(SplitTmp[WithoutSpace]);
                CheckLessThanZeroMoreThanTenthousand(SplitResult[i]);
                WithoutSpace++;
            }
            return SplitResult;
        }
        public int StringtoNum(string num)
        {
            int result;
            if (int.TryParse(num, out result))
                return result;
            else
                return -1;
        }
        public void FindWays(int point, int roadLength, List<Shortcut> shortcutInfo, Dictionary<List<Shortcut>,WayLength> findWay)
        {
            List<Shortcut> shortcuts = new List<Shortcut>();
            if (CheckCorrectShortcut(roadLength, shortcutInfo[point]))
            {
                for(int i = point+1; i < shortcutInfo.Count; i++)
                {
                    if (shortcutInfo[point].departPoint <= shortcutInfo[i].departPoint && shortcutInfo[i].departPoint <= shortcutInfo[point].arrivalPoint)
                    {
                        FindWays(i,roadLength,shortcutInfo,findWay);
                    }
                }
                shortcuts.Add(new Shortcut(shortcutInfo[point].departPoint, shortcutInfo[point].arrivalPoint, shortcutInfo[point].shortcutLength));
                if (!findWay.ContainsKey(shortcuts))
                {
                    findWay.Add(shortcuts, new WayLength());
                }
                findWay[shortcuts].pointLength = shortcutInfo[point].arrivalPoint;
                if (point - 1 < 0)
                    findWay[shortcuts].totalLength = shortcutInfo[point].departPoint + shortcutInfo[point].shortcutLength; 
                else
                    findWay[shortcuts].totalLength += (shortcutInfo[point - 1].arrivalPoint - shortcutInfo[point].departPoint) + shortcutInfo[point].shortcutLength;
                if(findWay[shortcuts].pointLength < roadLength)
                {
                    if (point != FindNextPoint(point, shortcutInfo))
                        FindNextWay(point, roadLength, shortcutInfo, shortcuts, findWay);
                }
            }
            else
                FindNextWay(point+1, roadLength, shortcutInfo, shortcuts, findWay);
           
        }
        public bool CheckCorrectShortcut(int roadLength, Shortcut targetShortcut)
        {
            if (targetShortcut.departPoint < targetShortcut.arrivalPoint && targetShortcut.arrivalPoint <= roadLength
                && targetShortcut.shortcutLength < targetShortcut.arrivalPoint - targetShortcut.departPoint)
                return true;
            else
                return false;
        }
        public int FindNextPoint(int point, List<Shortcut> shortcutInfo)
        {    
            for (int i = point + 1; i < shortcutInfo.Count; i++)
            {
                if (shortcutInfo[point].arrivalPoint <= shortcutInfo[i].arrivalPoint)
                {
                    point = i;
                    break;
                }    
            }
            return point;
        }
        public void FindNextWay(int point, int roadLength, List<Shortcut> shortcutInfo, List<Shortcut> shortcuts, Dictionary<List<Shortcut>, WayLength> findWay)
        {
            if (CheckCorrectShortcut(roadLength, shortcutInfo[point]))
            {
                for (int i = point + 1; i < shortcutInfo.Count; i++)
                {
                    if (shortcutInfo[point].departPoint <= shortcutInfo[i].departPoint && shortcutInfo[i].departPoint <= shortcutInfo[point].arrivalPoint)
                    {
                        FindWays(i, roadLength, shortcutInfo, findWay);
                    }
                }
                shortcuts.Add(new Shortcut(shortcutInfo[point].departPoint, shortcutInfo[point].arrivalPoint, shortcutInfo[point].shortcutLength));
                if (!findWay.ContainsKey(shortcuts))
                {
                    findWay.Add(shortcuts, new WayLength());
                }
                findWay[shortcuts].pointLength = shortcutInfo[point].arrivalPoint;
                if (point - 1 < 0)
                    findWay[shortcuts].totalLength = shortcutInfo[point].departPoint + shortcutInfo[point].shortcutLength;
                else
                    findWay[shortcuts].totalLength += (shortcutInfo[point - 1].arrivalPoint - shortcutInfo[point].departPoint) + shortcutInfo[point].shortcutLength;
                if (findWay[shortcuts].pointLength < roadLength)
                {
                    if (point != FindNextPoint(point, shortcutInfo))
                        FindNextWay(point, roadLength, shortcutInfo, shortcuts, findWay);
                }
            }
            else
                FindNextWay(point + 1, roadLength, shortcutInfo, shortcuts, findWay);
        }
        public void CheckLessThanZeroMoreThanTenthousand(int value)
        {
            if (value < 0 ||
                value > 10000)
            {
                Console.Write("Value is not Correct");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
        public void CheckWhileErrorInSplitInputString()
        {
            Console.Write("While Error");
            System.Threading.Thread.Sleep(2000);
        }
    }
}
