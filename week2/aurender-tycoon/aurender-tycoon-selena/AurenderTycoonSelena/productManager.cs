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
        private ProductInfo[] product = new ProductInfo[11];


        /* ProductInfo product 배열 초기화 */
        public void Init()
        {
            for (int i = 0; i < product.Length; i++)
                product[i] = new ProductInfo();
        }

        //사용 용도 : 판매 후, 초반 재고 채워넣기 
        //재고 관리 (data parameter input example : model,color,storage)
        public void ManageStock(string data, int stock)
        {
            string[] tmp_data = data.Split(',');

            for (int i = 0; i < product.Length; i++)
            {
                /* 일치한지 검사 */
                if(product[i].model.Equals(tmp_data[0]) && product[i].color.Equals(tmp_data[0]) 
                    && product[i].storage.Equals(tmp_data[0]))
                {
                    /* stock이 마이너스가 되는 경우 처리 */
                    if (product[i].stock + stock < 0)
                        Console.WriteLine("Stock value is minus!");
                    else
                        product[i].stock += stock;
                }
            }
        }

        public void SetData()
        {
            /**
             * 이 함수가 실행되는 조건 : 
             * 프로그램 최초 실행시 (sowrender - sowrender_product에 데이터가 하나도 존재하지 않을 경우)
             * row 개수를 받아와서 0일 경우 실행
             */


            /* 해당 위치에 존재하는 csv 파일 읽어와서 text라는 string 변수에 저장 */
            string text = File.ReadAllText(@"csv파일 절대 경로", Encoding.UTF8);

            /* 개행문자로 자르기 */
            string[] lines = text.Split('\n');

            /* 1부터 시작하는 이유 : 0번째 줄에는 컬럼 데이터가 들어가있음 */
            for (int i = 1; i < lines.Length; i++)
            {
                /* 잘린 데이터 : no,model_name,price,finish,storage,stock */
                string[] data = lines[i].Split(',');

                product[i - 1].model = data[1];
                product[i - 1].price = uint.Parse(data[2]);
                product[i - 1].color = data[3];
                product[i - 1].storage = data[4];
                product[i - 1].stock = 0; // stock에 N/A값 들어가있음
            }
        }

        /* 물건데이터가 저장된 배열 리턴하는 함수*/
        public ProductInfo[] GetProductData()
        {
            return product;
        }

    }
}
