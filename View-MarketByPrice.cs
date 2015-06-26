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
    public partial class MarketDepthByPrice : Form, StockMarketDisplay
    {
        public RealTimeData realdata;
        public Company comp;
        public MarketDepthByPrice(RealTimeData RTD, Company comp)
        {
            InitializeComponent();
            this.comp = comp; //the current compnay for this window
            this.Text += " " + comp.compName; //set the text at the top of the form
            Update(RTD); //add any data from the data model to the view
            realdata = RTD; //store a copy of the data model
            

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(delegate
            {
                realdata.unRegister(this);
            });
            
        }

        private void label1_Click(object sender, EventArgs e){

        }

        private void label2_Click(object sender, EventArgs e){

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){

        }

        public void Update(RealTimeData s) {

                List<BuyOrder> buylist = new List<BuyOrder>();
                int i = 0;
                foreach (BuyOrder value in comp.Buyorder)
                {
                    if (i < 10)
                        buylist.Add(value);
                    i++;
                }
                realdata = s;
                dataGridView1.Rows.Clear();
                IEnumerable<IGrouping<float, BuyOrder>> collection = buylist.GroupBy(b => b.orderPrice).OrderBy(b => b.Key).Reverse();

                foreach (IGrouping<float, BuyOrder> orders in collection)
                {

                    int vol = 0;

                    //go through each buyorder 
                    foreach (BuyOrder buyo in orders)
                    {
                        vol += buyo.orderSize;
                        //pocket full of mumbles
                        dataGridView1.Rows.Add(orders.Count(), vol, orders.Key);//orders.count() is how many times that order was made

                    }

                }

                IEnumerable<IGrouping<float, BuyOrder>> collection2 = buylist.GroupBy(b => b.orderPrice).OrderBy(b => b.Key).Reverse();



                dataGridView2.Rows.Clear();
                foreach (IGrouping<float, BuyOrder> orders2 in collection2)
                {



                    int vol = 0;

                    //go through each buyorder 
                    foreach (BuyOrder buyo in orders2)
                    {
                        vol += buyo.orderSize;
                        //pocket full of mumbles
                        dataGridView2.Rows.Add(orders2.Count(),vol, orders2.Key);//orders.count() is how many times that order was made

                    }

                }
            
            
        }
    }
}
