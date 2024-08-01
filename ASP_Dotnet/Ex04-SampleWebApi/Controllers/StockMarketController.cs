using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Data;


//Scaffold-DbContext "Server=.\SQLEXPRESS; Database=FnfTraining; Trusted_Connection=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data
namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMarketController : ControllerBase
    {
        private readonly FnfTrainingContext _context;

        public StockMarketController(FnfTrainingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Stocks")]
        //api/StockMarket/Stocks
        public List<StockTable> AllStocks()
        {
            var result = _context.StockTables.ToList();
            return result;
        }

        [HttpGet]
        [Route("Stocks/{id}")]
        ////api/StockMarket/Stocks/123
        public StockTable GetStock(int id)
        {
           var res =  _context.StockTables.FirstOrDefault(s => s.StockId == id);
            if (res == null)
            {
                throw new Exception("No Stock found");
            }
            return res;
        }

        [HttpPost]
        [Route("Stocks")]
        //api/StockMarket/Stocks
        public ObjectResult AddStock(StockTable stock)
        {
            _context.StockTables.Add(stock);
            _context.SaveChanges();
            return Ok("Added Successfully");
        }

        //Updating the record...
        [HttpPut]
        [Route("Stocks")]
        public IActionResult PutStock(StockTable stock)
        {
            //Find the record based on the StockId
            var rec = _context.StockTables.FirstOrDefault(s => stock.StockId == s.StockId);
            if(rec == null)
            {
                return NotFound("Record not found");
            }
            //Update the record with the arg data
            rec.StockName = stock.StockName;
            rec.StockDescription = stock.StockDescription;
            rec.UnitPrice = stock.UnitPrice;
            //Save changes. 
            _context.SaveChanges();
            return Ok("Stocks Updated Successfully");
        }

        [HttpDelete]
        [Route("Stocks/{id}")]
        public IActionResult DeleteStock(int id)
        {
            var rec = _context.StockTables.FirstOrDefault(s => id == s.StockId);
            if (rec == null)
            {
                return NotFound("Record not found");
            }
            _context.StockTables.Remove(rec);
            _context.SaveChanges();
            return Ok(rec);
        }
    }
}
