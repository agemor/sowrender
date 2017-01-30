using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurenderTycoonErica
{
    class SalesManager
    {
        /* 매출 */
        private int sales=0;
        private ProductManager product = ProductManager.GetInstance();
        private CustomerManager customer = CustomerManager.GetInstance();

        /* 싱글톤 */
        static protected SalesManager _instance;

        /* 영수증 */
        private List<Reciept> reciept;
        public List<Reciept> Reciept { get { return this.reciept; } }

        /* 싱글톤 */
        protected SalesManager() { }
        static public SalesManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SalesManager();
            }
            return _instance;
        }

        /* 구매가 됐으면 true, 되지 않으면 false 반환 */
        public Boolean Purchase(Product p, Customer c)
        {
            product.
            //재고가 남아있는지 확인 후
            //+매출
            //stock- (산 수량만큼)
            //손님 판매 수 +
        }

        /* 환불이 됐으면 true, 되지 않으면 false 반환 */
        public bool Refund(Product p, Customer c)
        {
            if (PurchaseCheck(p,c))
            {
                sales -= p.AttributeList[0].Price;
                product.ManageStock(p);
                c.Count += p.AttributeList[0].Stock;
                return true;
            }
            return false;

        }

        /* 환불할 수 있는 대상인지 체크 
         (예전에 구매내역이 있는지 체크)*/
        private bool PurchaseCheck(Product p, Customer c)
        {

        }

    }
}
