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
    public partial class MainForm : Form
    {
        public RealTimeData RTD = new RealTimeData();
      
        public MainForm()
        {
            InitializeComponent();

            //looping thru companies
            foreach (Company comp in RTD._company)
            {
                //make the drop down list with all the companies
                ToolStripMenuItem biteme = new ToolStripMenuItem();
                biteme.Text = comp.compName;
                biteme.Name = "foo";

                ToolStripMenuItem eatme = new ToolStripMenuItem();
                eatme.Text = comp.compName;
                eatme.Name = "boo";

                biteme.Click += new EventHandler(delegate
                    {//create the appropriate form 
                        MarketDepthByOrder MarketByOrder = new MarketDepthByOrder(this.RTD, comp);
                        // Set the parent form of the child window.
                        MarketByOrder.MdiParent = this;
                        // Display the new form.
                        MarketByOrder.Show();
                        MarketByOrder.Update(this.RTD);
                        //register the view
                        RTD.Register(MarketByOrder);
                    }
                    );
                eatme.Click += new EventHandler(delegate
                    {
                        MarketDepthByPrice MarketByPrice = new MarketDepthByPrice(this.RTD,comp);
                        // Set the parent form of the child window.
                        MarketByPrice.MdiParent = this;
                        // Display the new form.
                        MarketByPrice.Show();
                        MarketByPrice.Update(this.RTD);
                        
                        //register the view
                        RTD.Register(MarketByPrice);
                    });
                    
                //add the forms to the drop down
                marketByOrderToolStripMenuItem.DropDownItems.Add(biteme);
                marketByPriceToolStripMenuItem.DropDownItems.Add(eatme);

               
            }

            //make a state summary form
         
            StateSummary StockStateSummary = new StateSummary(this.RTD);
           //register the obserer
            RTD.Register(StockStateSummary);
           

          
        }

        private void stockStateSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateSummary StockStateSummary = new StateSummary(this.RTD);
            // Set the parent form of the child window.
            StockStateSummary.MdiParent = this;
            // Display the new form.
            
            RTD.Register(StockStateSummary);
            RTD.Notify();
            StockStateSummary.Show();

        }

   

        private void beginTradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopTradingToolStripMenuItem.Enabled = true;
            beginTradingToolStripMenuItem.Enabled = false;
            marketClosedToolStripMenuItem.Text = "Market <<Open>>";
            watchMenuItem.Visible = true;
            ordersMenuItem.Visible = true;

        }

        private void stopTradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopTradingToolStripMenuItem.Enabled = false;
            beginTradingToolStripMenuItem.Enabled = true;
            marketClosedToolStripMenuItem.Text = "Market <<Closed>>";
            watchMenuItem.Visible = false;
            ordersMenuItem.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void bidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaceBid newWindow = new PlaceBid(RTD);
            newWindow.MdiParent = this;
            newWindow.Show();
        }

        private void askToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            PlaceSell newWindow = new PlaceSell(RTD);
            newWindow.MdiParent = this;
            newWindow.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cascade all MDI child windows.
            this.LayoutMdi(MdiLayout.Cascade);

        }

        private void horizontalTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tile all child forms horizontally.
            this.LayoutMdi(MdiLayout.TileHorizontal);
        
        }

        private void verticleTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tile all child forms vertically.
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Put in code here to access the Application data model and populate the Market by Order and Market by Price 
            //for each company
        }
    }
}
