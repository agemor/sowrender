using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortcut_selena
{
    public class ShortCut
    {
        public int departurePoint;
        public int destinationPoint;
        public int length;
        public bool isFast = false; // 실제로 빠른지 검사

        public ShortCut(int start, int finish, int len) {
            this.departurePoint = start;
            this.destinationPoint = finish;
            this.length = len;
            
            if(len < finish - start) {
                isFast = true;
            }
        }
    }
}
