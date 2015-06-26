using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockStuff
{
    public class BuyOrder: Order
    {
        
        public DateTime orderDate; 
        public int orderSize;
        public float orderPrice;
        public string shareName;
 

 
        public BuyOrder() { }

        public BuyOrder(int orderSz, float orderPrc, string share) {
       
            this.orderSize = orderSz;
            this.orderPrice = orderPrc;
            this.orderDate = DateTime.Now;
            this.shareName = share;

          

        }

        public void setPrice(){

        }
        public float getPrice()
        {
return 4.4f;
        }

      
    }
}
