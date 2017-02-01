using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AurenderTycoonSelena
{
    class ProductManager
    {
        /* 싱글톤 */
        //-------------------------------------------------------
        private static ProductManager _instance;

        protected ProductManager() { }

        public static ProductManager GetInstance()
        {
            /* 한 번도 생성 안된 경우 생성 */
            if (_instance == null)
            {
                _instance = new ProductManager();
            }

            return _instance;
        }
        //-------------------------------------------------------

        private ProductInfo[] product = new ProductInfo[12];

        //사용 용도 : 판매 후, 초반 재고 채워넣기
        public bool ManageStock(string model, string color, string storage, int stock)
        {
            for (int i = 0; i < product.Length; i++)
            {
                /* 일치한지 검사 */
                if (product[i].Model.Equals(model) && product[i].Color.Equals(color)
                    && product[i].Storage.Equals(storage))
                {
                    /* stock이 마이너스가 되는 경우 처리 */
                    if (product[i].Stock - stock < 0)
                        break;

                    product[i].Stock -= stock;
                    return true; // 성공
                }
            }
            return false;
        }

        public void SetData()
        {
            /**
             * 이 함수가 실행되는 조건 : 
             * 프로그램 최초 실행시 (sowrender - sowrender_product에 데이터가 하나도 존재하지 않을 경우)
             * row 개수를 받아와서 0일 경우 실행
             */
            DBManager mDBManager = DBManager.GetInstance();
            int rowDataCount = mDBManager.GetRowCount("sowrender_product");

            /* row의 개수가 0이 아닌 경우 -> 즉, 데이터가 있는 경우 바로 종료*/
            if (rowDataCount != 0)
            {
                return;
            }

            /* 해당 위치에 존재하는 csv 파일 읽어와서 text라는 string 변수에 저장 */
            string text = File.ReadAllText("../../initialData.csv", Encoding.UTF8);

            /* 개행문자로 자르기 */
            string[] lines = text.Split('\n');

            /* 1부터 시작하는 이유 : 0번째 줄에는 컬럼 데이터가 들어가있음 */
            for (int i = 1; i < lines.Length; i++)
            {
                product[i - 1] = new ProductInfo(lines[i]);
            }

            /* query문 작성*/
            for (int i = 0; i < product.Length; i++)
            {
                mDBManager.ExecuteQuery("insert into sowrender_product values('" + product[i].Model + "','"
                    + product[i].Color + "','" + product[i].Storage + "'," + product[i].Price + ",'"
                    + product[i].Stock + "');");
            }
        }

        /* 물건데이터가 저장된 배열 리턴하는 함수*/
        public ProductInfo[] GetProductData()
        {
            return product;
        }

    }
}
