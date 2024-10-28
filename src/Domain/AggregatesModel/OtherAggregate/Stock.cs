using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.OtherAggregate
{
    public class Stock
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public double ChangePercentage { get; set; }
        public long Volume { get; set; }
        public DateTime LastUpdate { get; set; }

        public Stock(string symbol, double price, double change, 
            double changePercentage, long volume, DateTime lastUpdate)
        {
            Symbol = symbol;
            Price = price;
            Change = change;
            ChangePercentage = changePercentage;
            Volume = volume;
            LastUpdate = lastUpdate;
        }
    }
}
