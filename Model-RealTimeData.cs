using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockStuff
{
    public class RealTimeData: StockMarket
    {
        public DateTime tradingDate;
        public List<Company> _company;
        public List<StockMarketDisplay> _stock;
        public int stockIndex; //not implemented

       public RealTimeData() {
           //lists to store companies and stock views
            this._company = new List<Company>();
            this._stock = new List<StockMarketDisplay>();
            this.tradingDate = DateTime.Now;    
           //instantiate 3 companies
            Company Microsoft= new Company("Microsoft", 46.13f );
            Company Apple= new Company("Apple Inc.", 105.22f );
            Company Facebook = new Company("Facebook", 80.67f );
            _company.Add(Microsoft);
            _company.Add(Apple);
            _company.Add(Facebook);

        }
        //add the views to the list, remove them and update
       public override void Register(StockMarketDisplay o) {
           _stock.Add(o);
       }
       public override void unRegister(StockMarketDisplay o) {
           _stock.Remove(o);
       }
       public override void Notify() { 
           foreach(StockMarketDisplay value in _stock)
           {
               value.Update(this);
           }
       }


    }
}
