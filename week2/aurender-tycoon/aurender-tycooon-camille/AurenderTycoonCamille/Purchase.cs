using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonCamille
{
    /**
     *  This class used like structer of purchase data
     *  
     *  date 2017/01/25
     */
    class PurchaseData
    {
        //kind
        //color
        //capacity
        //amount
        //+client information : discount & address
    }

    /**
     * This class processes purchase request
     * 
     * date 2017/01/25
     */
    class PurchaseRequest
    {
        /* collect whole purchase */
        void HistoryOfPurchase()
        {
            var history = new Dictionary<string, PurchaseData>();
        }

        /* extract product price */
        double PriceOfRequest(int option)
        {
            double price = 0;
            //make whole price with selected option
            return price;
        }

        /* repund process */
        void RepundPurchase(Dictionary<string, PurchaseData> history)
        {
            //started when order amount is less then 0
            //using matched client and find in dictionary
            //if there is correct client and product, allow repund
        }
    }
}
