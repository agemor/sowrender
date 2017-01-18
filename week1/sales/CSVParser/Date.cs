using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    class Date
    {
        int year;
        int month;
        int day;

        public Date(string date)
        {
            string[] temp = date.Split('/');

            this.year = int.Parse(temp[0]);
            this.month = int.Parse(temp[1]);
            this.day = int.Parse(temp[2]);
        }
    }
}
