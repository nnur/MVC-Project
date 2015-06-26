using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockStuff
{
    public partial class MarketDepthByOrder : Form, StockMarketDisplay
    {
        //MEMBER VARIABLES
        public float bidPrice;
        public int bidVolume;
        public float askPrice;
        public int askVolume;
        public RealTimeData realdata;
        public Company comp;
        //CONSTRUCTORS======================
        public MarketDepthByOrder(RealTimeData RTD, Company comp)
        {
            //some image stuff
            InitializeComponent();
            this.comp = comp;
            this.Text += " " + comp.compName;
            Update(realdata);
            realdata = RTD;
           

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(delegate
            {
                realdata.unRegister(this);
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Update(RealTimeData s)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

           
                List<BuyOrder> buylist = new List<BuyOrder>();
                int i = 0;
                foreach (BuyOrder value in comp.Buyorder)
                {

                    if (i < 10)
                        buylist.Add(value);
                    i++;
                }


                List<SellOrder> sellList = new List<SellOrder>();
                int j = 0;
                foreach (SellOrder value in comp.Sellorder)
                {

                    if (j < 10)
                        sellList.Add(value);
                    j++;
                }
                realdata = s;
                dataGridView1.Rows.Clear();
                IEnumerable<IGrouping<float, BuyOrder>> collection = buylist.GroupBy(b => b.orderPrice).OrderBy(b => b.Key).Reverse();


                foreach (IGrouping<float, BuyOrder> orders in collection)
                {



                    int vol = 0;

                    dataGridView1.Rows.Clear(); //clear all the old data

                    //go through each buyorder 
                    foreach (BuyOrder buyo in orders)
                    {
                        vol += buyo.orderSize;
                        //pocket full of mumbles
                        dataGridView1.Rows.Add(vol, orders.Key);//orders.count() is how many times that order was made

                    }

                }

                IEnumerable<IGrouping<float, SellOrder>> collection2 = sellList.GroupBy(b => b.orderPrice).OrderBy(b => b.Key).Reverse();




                foreach (IGrouping<float, SellOrder> orders2 in collection2)
                {



                    int vol = 0;


                    dataGridView2.Rows.Clear(); //clear all the old data
                    //go through each buyorder 
                    foreach (SellOrder buyo in orders2)
                    {
                        
                        vol += buyo.orderSize;
                        //pocket full of mumbles
                        dataGridView2.Rows.Add( vol, orders2.Key);//orders.count() is how many times that order was made

                    }

                }
            
        }
    }
}
