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
        public List<StockTable> AllStocks()
        {
            var result = _context.StockTables.ToList();
            return result;
        }

        [HttpPost]
        [Route("Stocks")]
        public ObjectResult AddStock(StockTable stock)
        {
            _context.StockTables.Add(stock);
            _context.SaveChanges();
            return Ok("Added Successfully");
        }
    }
}
