using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenderTycoonSelena
{
    class SellingProduct
    {
        bool isSuccess = false;
        //물건 팔기

       /* data parameter input example : model,color,storage */
        public void checkAvailableData(ProductInfo[] productToBuy, string data)
        {
            if (true/* 클라이언트가 입력한 데이터가 유효한지 확인*/)
                isSuccess = true; // 유효할 경우 true 반환
            else
                isSuccess = false;
        }

        public void refundProduct() {
            //유저가 인풋한 값에서 stock 항목의 값이 마이너스일 경우 현재 함수 실행

        }

        public void sellProduct(ProductInfo product)
        {
            /* 물건이 유효하지 않으면, 바로 종료 */
            if (!isSuccess)
                return;

            //판매

        }
        

    }
}
