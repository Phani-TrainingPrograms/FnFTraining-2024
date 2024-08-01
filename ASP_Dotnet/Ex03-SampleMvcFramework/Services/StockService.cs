using SampleMvcFramework.Data;
using SampleMvcFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcFramework.Services
{
    public interface IStockService
    {
        void AddStock(Stock stock);
        void DeleteStock(int stockId);
        Stock GetStockById(int id);
        List<Stock> GetStocks();
        void UpdateStock(Stock stock);
    }

    public class StockService : IStockService
    {
        private readonly FnfTrainingEntities _trainingEntities;
        public StockService()
        {
            _trainingEntities = new FnfTrainingEntities();
        }

        public List<Stock> GetStocks()
        {
            List<Stock> stocks = new List<Stock>();
            //get the data from the datacontext. 
            var data = _trainingEntities.StockTables.ToList();
            //convert each rec of the data into Stock object
            foreach (var dataRow in data)
            {
                Stock rec = new Stock();
                rec.CopyFrom(dataRow);
                stocks.Add(rec);
            }
            //return the list of the stock objects.
            return stocks;
        }

        public Stock GetStockById(int id)
        {
            var row = _trainingEntities.StockTables.FirstOrDefault(s => s.stockId == id);
            if (row == null)
            {
                throw new Exception("Stock not found");
            }
            var stock = new Stock();
            stock.CopyFrom(row);
            return stock;
        }
        public void AddStock(Stock stock)
        {
            //Convert the stock model to stock table object
            var row = new StockTable
            {
                stockName = stock.StockName,
                stockDescription = stock.StockDescription,
                unitPrice = stock.UnitPrice
            };
            //Add the stock table object to the dbcontext collection
            _trainingEntities.StockTables.Add(row);
            //save changes to the database
            _trainingEntities.SaveChanges();
        }

        public void DeleteStock(int stockId)
        {
            var foundStock = _trainingEntities.StockTables.FirstOrDefault(s => s.stockId == stockId);
            if (foundStock == null)
            {
                throw new Exception("Stock not found to delete");
            }
            _trainingEntities.StockTables.Remove(foundStock);
            _trainingEntities.SaveChanges();
        }

        public void UpdateStock(Stock stock)
        {
            //find the matching record based on id
            var foundStock = _trainingEntities.StockTables.FirstOrDefault(s => s.stockId == stock.StockId);
            if (foundStock == null)
            {
                throw new Exception("Stock not found to update");
            }
            //set the updated values from the stock to the row
            foundStock.unitPrice = stock.UnitPrice;
            foundStock.stockDescription = stock.StockDescription;
            foundStock.stockName = stock.StockName;
            //save the changes. 
            _trainingEntities.SaveChanges();
        }

    }
}