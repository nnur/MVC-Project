using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using StockStuff.Properties;

namespace StockStuff
{
    public class Company
    {
        public string compName;  //set by realtimedata
        public float openingPrice;       //set by realtimedata
        public float lastPrice;       //last sale price
        public float NetChange;       //the net change
        public double percentageChange;
        public int VolumeOfShare; //number of shares sold
        public Image image;
        public ArrayList Buyorder;
        public ArrayList Sellorder;
        
     
        public Company()
        {
            //init stsuff
            this.Buyorder = new ArrayList();
            this.Sellorder = new ArrayList();
            this.image = Resources.noChange;
        }

        public Company(string compName, float opPrice)
        {
            //init attributes
            this.compName = compName;
            this.openingPrice = opPrice;
            this.Buyorder = new ArrayList();
            this.Sellorder = new ArrayList();
            this.lastPrice = opPrice;           
            this.NetChange = 0;
            this.percentageChange = 0;
            this.image = Resources.noChange;
        }

        public void setNewValues(float newPrice, int volume){   //sets the values

            this.NetChange = newPrice - this.lastPrice;
            this.lastPrice = newPrice;
            this.VolumeOfShare = volume;
            this.percentageChange = (NetChange / openingPrice)*100; //the change over the initial price

            if (NetChange == 0) //change the image
            {
                this.image = Resources.noChange;
                
            }

            else if (NetChange < 0)
            {
                this.image = Resources.down;
            }
            else
            {
                this.image = Resources.up;
            }



        }

        public float getLastPrice()
        {

            return this.lastPrice;   
        }
        public int getVolume() {

            return 0;   //change later, this is the stockVolume I am wondering about
        }

        public void BidSellMatch() //check for buy sell match
        {
            ArrayList removeBids = new ArrayList();
            ArrayList removeSells = new ArrayList();
            
            foreach (BuyOrder bid in Buyorder) //go through all buy orders
            {
               
                foreach (SellOrder sell in Sellorder) //go through all sell orders
                {
                
                    if ((sell.Name == bid.shareName) && (sell.orderPrice == bid.orderPrice) && (sell.orderSize == bid.orderSize)) //makes a transaction
                    {

                        Console.Write("  match made");
                        removeBids.Add(bid);
                        removeSells.Add(sell);
                        setNewValues(sell.orderPrice, bid.orderSize); //set the new values
                    }
                }
               
            }

            foreach(BuyOrder buy in removeBids)
            {
                Buyorder.Remove(buy);
            }

            foreach (SellOrder buy in removeSells)
            {
                Sellorder.Remove(buy);
            }

            
        }
    }
}
