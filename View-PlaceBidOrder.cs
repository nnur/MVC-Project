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
    public partial class PlaceBid : Form
    {
       public RealTimeData realdata; //store the realdata yo

        public PlaceBid(RealTimeData r)
        {
            InitializeComponent();
            realdata = r; //passed in through mainform. has list of companies
            foreach (Company value in realdata._company)
            {
                comboBox1.Items.Add(value.compName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string company = comboBox1.Text; //strings from the box
            string num_of_shares = textBox1.Text;
            string money = textBox2.Text;

            int shareSize = Convert.ToInt32(num_of_shares); //make string data into ints
            float price = Convert.ToSingle(money);

            BuyOrder buyorder = new BuyOrder(shareSize, price, company);

            foreach (Company value in realdata._company) //go through all companies
            {
                if (value.compName == company)
                {
                    value.Buyorder.Add(buyorder);  //add the order to the list of orders in company
                    value.BidSellMatch(); //check for transaction
                    realdata.Notify(); //update all views

                }
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

         
    }
}
