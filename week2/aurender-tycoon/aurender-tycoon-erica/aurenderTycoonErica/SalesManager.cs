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
        private int sales = 0;
        private ProductManager productManager = ProductManager.GetInstance();
        private CustomerManager customerManager = CustomerManager.GetInstance();

        /* 싱글톤 */
        static protected SalesManager _instance;

        /* 영수증 */
        private List<Reciept> reciept = new List<aurenderTycoonErica.Reciept>();
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
        public void Purchase(Product p, Customer c)
        {
            /* 실제 살 수 있는 수량 */
            int actualQuantity = productManager.ManageStock(p);
            sales += actualQuantity * p.Price;
            customerManager.ManageCount(c, actualQuantity);
            p.Stock = actualQuantity;
            AddReciept(p, c);
        }

        /* 환불이 됐으면 true, 되지 않으면 false 반환 */
        public void Refund(Product p, Customer c)
        {
            /* 환불할 수 있는 수량 반환 */
            p.Stock = PossibelRefundAmount(p, c);
                   sales += p.Price * p.Stock;
            int amount = productManager.ManageStock(p);
            customerManager.ManageCount(c, amount);
            AddReciept(p, c);

        }

        /* 환불할 수 있는 수량을 리턴
         (예전에 구매내역이 있는지 체크)*/
        private int PossibelRefundAmount(Product p, Customer c)
        {
            Customer storedCustomerData = new Customer();

            /* 새로 온 손님인 경우 false*/
            if (!customerManager.CustomerData.TryGetValue(c.PhoneNumber, out storedCustomerData))
            {
                return 0;
            }

            int totalCustomerPurchases = 0;

            /* 영수증에서 기록이 있나 살펴봄 */
            for (int i = reciept.Count - 1; i >= 0; i--)
            {
                if (reciept[i].CustomerData.PhoneNumber == storedCustomerData.PhoneNumber
                    && reciept[i].ModelName == p.ModelName
                    && reciept[i].ModelColor == p.Color
                    && reciept[i].Capacity == p.Capacity)
                {
                    totalCustomerPurchases += reciept[i].Amount;
                }

                if (totalCustomerPurchases >= (p.Stock*-1))
                {
                    return p.Stock;
                }
            }
            return totalCustomerPurchases * -1;
        }

        /* 영수증에 내용 추가 */
        public void AddReciept(Product p, Customer c)
        {
            DateTime now = System.DateTime.Now;
            Reciept r = new Reciept(p.ModelName, p.Color, p.Capacity, p.Price, p.Stock, now, c);

            reciept.Add(r);
        }

    }
}
