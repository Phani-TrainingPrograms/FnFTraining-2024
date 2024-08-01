using Microsoft.AspNetCore.Mvc;
using SampleApiMvcClient.Models;
using SampleApiMvcClient.Services;
using System.Diagnostics;

namespace SampleApiMvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStockService _stockService;

        public HomeController(IStockService service)
        {
            _stockService = service;
        }

        public IActionResult Index()
        {
            var stocks = _stockService.GetAllStocks();
            return View(stocks);
        }


        public IActionResult Details(int id)
        {
            var model = _stockService.GetStockById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Details(Stock postedData)
        {
            try
            {
                _stockService.UpdateStock(postedData);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(postedData);
            }
        }

        public IActionResult AddNew() => View(new Stock());

        [HttpPost]
        public IActionResult AddNew(Stock postedData)
        {
            try
            {
            _stockService.AddNewStock(postedData);
            return RedirectToAction("Index");   
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(postedData);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
