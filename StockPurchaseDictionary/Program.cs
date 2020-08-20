using System;
using System.Collections.Generic;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("AA", "Alcoa");
            stocks.Add("F", "Ford");
            stocks.Add("AAPL", "Apple Computer");
            stocks.Add("AET", "Aetna");

            string GM = stocks["GM"];
        }
    }
}
