using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockStuff
{
    public class SellOrder: Order
    {
        //list of variables
        public DateTime orderDate;
        public int orderSize;
        public float orderPrice;
        public string Name;
        

        public SellOrder() { }

        public SellOrder(int orderSz, float orderPrc, string share)
        {
      
            this.orderSize = orderSz;
            this.orderPrice = orderPrc;
            this.orderDate = DateTime.Now;
            this.Name = share;
          
        }

        public void setPrice()
        {
           

            
        }

        public float getPrice()
        {
            return this.orderPrice;
        }
    }
}
