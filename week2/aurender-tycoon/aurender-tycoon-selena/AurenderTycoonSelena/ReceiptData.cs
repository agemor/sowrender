using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class ReceiptData
    {
        private uint index; // primaryKey(unique) : 주문 번호와 같은 역할
        private uint amountNum;
        private string purchasedModel;

        public ReceiptData(uint index, uint amountNum, string purchasedModel)
        {
            this.index = index;
            this.amountNum = amountNum;
            this.purchasedModel = purchasedModel;
        }

        public uint getIndex()
        {
            return index;
        }
    }
}
