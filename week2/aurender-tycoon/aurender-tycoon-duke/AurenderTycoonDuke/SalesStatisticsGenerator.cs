using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonDuke
{
    class SalesStatisticsGenerator
    {
        private static SalesStatisticsGenerator _instance;
        protected SalesStatisticsGenerator() { }
        static public SalesStatisticsGenerator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SalesStatisticsGenerator();
            }
            return _instance;
        }
        ReceiptManager receiptManager = ReceiptManager.GetInstance();

        public void ViewReceiptBySale()
        {
            receiptManager.PrintReceiptList();
        }
        public void ViewSalesVolume()
        {

        }
        public void ViewSalesVolumeByProduct()
        {

        }
        public void ExportCsv()
        {

        }
    }
}
