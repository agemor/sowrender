using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortcut_selena
{
    class QuickSort
    {
        public void sort(ShortCut[] data, int l, int r)
        {
            ShortCut temp;
            int left = l, right = r;
            int pivot = data[(l + r) / 2].departurePoint;

            do
            {
                while (data[left].departurePoint < pivot) left++;
                while (data[right].departurePoint > pivot) right--;
                if (left <= right)
                {
                    temp = data[left];
                    data[left] = data[right];
                    data[right] = temp;

                    left++;
                    right--;
                }
            } while (left <= right);

            if (l < right)
                sort(data, l, right);
            if (r > left)
                sort(data, left, r);
        }
    }
}
