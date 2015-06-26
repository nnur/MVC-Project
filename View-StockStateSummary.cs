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
  
    public partial class StateSummary : Form, StockMarketDisplay
    {
        //MEMBER VARIABLES
        public string companyName;
        public string companySymbol;    //need to make a img class of some sort
        public float openPrice;
        public float currentPrice;
        public float priceChange;
        public float percentageChange;
        public RealTimeData realdata;

   

        public StateSummary()
        {
  
            InitializeComponent();

            
        }

        //this.Update(s);
        public StateSummary(RealTimeData rdata)
        {
            
            InitializeComponent();

            dataGridView1.Rows.Add(2);
           
            this.realdata = rdata;
            this.companyName = rdata._company[0].compName;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(delegate {
                realdata.unRegister(this);
            });
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

            Console.Write("heheheheheh"+realdata);
            Update(realdata);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Update(RealTimeData s)
        {
            realdata = s;
            Console.Write("updatingggggggggggggggggggggggggggggggg");
            //setting the values
            dataGridView1.Rows[0].SetValues(realdata._company[0].compName, "PAPA", realdata._company[0].openingPrice, realdata._company[0].lastPrice, realdata._company[0].NetChange, null, realdata._company[0].percentageChange, realdata._company[0].VolumeOfShare);
            dataGridView1.Rows[1].SetValues(realdata._company[1].compName, "PAPA", realdata._company[1].openingPrice, realdata._company[1].lastPrice, realdata._company[1].NetChange, null, realdata._company[1].percentageChange, realdata._company[1].VolumeOfShare);
            dataGridView1.Rows[2].SetValues(realdata._company[2].compName, "PAPA", realdata._company[2].openingPrice, realdata._company[2].lastPrice, realdata._company[2].NetChange, null, realdata._company[2].percentageChange, realdata._company[2].VolumeOfShare);
           //puts images in the 5th column
            dataGridView1[5, 0].Value = realdata._company[0].image; 
            dataGridView1[5, 1].Value = realdata._company[1].image;
            dataGridView1[5, 2].Value = realdata._company[2].image;
        }


    }
}
