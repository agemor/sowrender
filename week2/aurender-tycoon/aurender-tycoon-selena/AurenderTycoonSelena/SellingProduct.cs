using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class SellingProduct
    {
        //물건 팔기

        public bool checkAvailableData(ProductInfo productToBuy)
        {
            return true; // 유효할 경우 true 반환
        }

        public void refundProduct() { }

        public void sellProduct(ProductInfo product)
        {
            if (!checkAvailableData(product))
                return;

            //판매

        }
        

    }
}
