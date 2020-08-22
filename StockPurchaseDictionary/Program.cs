using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("GE", "General Electric");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("AA", "Alcoa");
            stocks.Add("F", "Ford");
            stocks.Add("AAPL", "Apple Computer");
            stocks.Add("AET", "Aetna");

            string GM = stocks["GM"];
            //Console.WriteLine(GM);

            //stock purchases:
            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add((ticker: "GE", shares: 150, price: 23.21));
            purchases.Add((ticker: "GE", shares: 32, price: 17.87));
            purchases.Add((ticker: "GM", shares: 80, price: 19.02));
            // Add more for each stock you added to the stocks dictionary
            purchases.Add((ticker: "CAT", shares: 100, price: 24.05));
            purchases.Add((ticker: "AA", shares: 57, price: 12));
            purchases.Add((ticker: "F", shares: 200, price: 55.55));
            purchases.Add((ticker: "AAPL", shares: 45, price: 450.59));
            purchases.Add((ticker: "AET", shares: 20, price: 12.99));

            //Create a total ownership report that computes the total value of each stock that you have purchased.
            //This is the basic relational database join algorithm between two tables.

            Console.WriteLine("Ownership Report");
            foreach(var recentPurchase in purchases)
            {
                double totalValue = recentPurchase.shares * recentPurchase.price; //MOVING this to the final code block below
                Console.WriteLine($"{recentPurchase.ticker}: Total value for this stock is {totalValue};");
            }
             

            /*
             * Define a new Dictionary to hold the aggregated purchase information. - The key should be a string that is the full company name.
             * The value will be the valuation of each stock (price*amount) { "General Electric": 35900, "AAPL": 8445, ... }
            */
            var aggregatedData = new Dictionary<string, double>();


            //ANCA: final code block including all required actions:
            // Iterate over the purchases and update the valuation for each stock
            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                double totalValue = purchase.shares * purchase.price; 

                // Does the company name key already exist in the report dictionary?
                foreach(var (companyTicker, companyName) in stocks)
                    if (companyTicker == purchase.ticker)
                    {
                        if (aggregatedData.ContainsKey(companyName))
                        // If it does, update the total valuation
                        {
                            aggregatedData[companyName] = aggregatedData[companyName] + totalValue; //ANCA: Note: This means that we take the value (which is the total amount) of the aggregatedData record at that Key/index value and we add to it the new totalValue identified for the row that has the same company name!!!
                        }
                        // If not, add the new key and set its value
                        else
                        {
                            aggregatedData.Add(companyName, totalValue);
                        }
                    }
            }

            Console.WriteLine();
            Console.WriteLine("Final Stocks Value Report");
            foreach (var (name, total) in aggregatedData)
            {
                Console.WriteLine($"{name}: {total}");
            }

        }
    }
}
