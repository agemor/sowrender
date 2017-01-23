using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    class Date
    {
        private int year;
        private int month;
        private int day;

        /* input data : dd/mm/yy */
        public Date(string date)
        {
            string[] temp = date.Split('/');

            this.year = int.Parse(temp[2]);
            this.month = int.Parse(temp[1]);
            this.day = int.Parse(temp[0]);
        }

        public int getYear()
        {
            return year;
        }
    }
}
