using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockStuff
{
    public abstract class StockMarket
    {
  
        //abstract class
        public abstract void Register(StockMarketDisplay o);
        public abstract void unRegister(StockMarketDisplay o);
        public abstract void Notify();

    }
}
