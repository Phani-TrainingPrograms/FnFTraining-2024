using SampleMvcFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Web;

namespace SampleMvcFramework.Models
{
    public class Stock
    {
        public Stock()
        {
            
        }
        public Stock(int id, string name, string desc, double uPrice)
        {
            StockId = id;
            StockName = name;
            StockDescription = desc;
            UnitPrice = uPrice;
        }

        public void CopyFrom(StockTable table)
        {
            StockId = table.stockId;
            StockName = table.stockName;
            StockDescription = table.stockDescription;
            UnitPrice = table.unitPrice;
        }

        public void CopyTo(Stock stock, StockTable table)
        {
            table.stockId = StockId;
            table.stockName = StockName;
            table.stockDescription = StockDescription;
            table.unitPrice = UnitPrice;
        }
        public int StockId { get; set; }
        public string StockName { get; set; }
        public string StockDescription { get; set; }
        public double UnitPrice { get; set; }


        //We dont want to include html elements inside our C# code. This is against the principle of Seperation of Concerns which was one of the reasons of creating MVC in ASP.NET. 
        //public override string ToString()
        //{
        //    return $"<h1>Stock Name: {StockName}</h1><hr/><p>{StockDescription}</p><p>Unit Price: {UnitPrice}</p>";
        //}
    }
}