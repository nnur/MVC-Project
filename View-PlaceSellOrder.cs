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
    public partial class PlaceSell : Form
    {
        RealTimeData realdata;
        public PlaceSell(RealTimeData r)
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

        private void button1_Click(object sender, EventArgs e)//submit button clicked
        {
            //get the input values
            string company = comboBox1.Text;
            string num_of_shares = textBox1.Text;
            string money = textBox2.Text;

            int shareSize = Convert.ToInt32(num_of_shares);
            float price = Convert.ToSingle(money);

            //make new sell order
            SellOrder sellorder = new SellOrder(shareSize, price, company);
         
            //get all the companies in the list
            foreach (Company value in realdata._company)
            {
                //find the right company for the sell order
                if (value.compName == company)
                {
                    value.Sellorder.Add(sellorder); //add the sell order to the company
                    value.BidSellMatch(); //check for match with bid orders
                    Console.Write("sell order added");
                   // realdata._stock[0].Update(realdata);
                  //  realdata._stock[1].Update(realdata);
                    realdata.Notify();
                }
            }
        }
    }
}
