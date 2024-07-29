using SampleMvcFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcFramework.Controllers
{
    //All methods inside a controller are called as ACTIONs. Their return value will be an ActionResult which is an abstract class which will be implemented by many classes that return specific results: Json, View, PartialView, RedirectResult and many more. 

    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Hello World";
        }
        //HTTP is a text based protocol. when a request returns an object. its string representation is returned as RESPONSE. 
        public ViewResult Display()
        {
            var model = new Stock { StockId = 123, StockDescription = "Stock Investments on Infrastructure", StockName = "HDFC Infrastructure Equity Fund", UnitPrice = 13.34545 };
            return View(model); 
            //Every controller will have a method called View that returns a Viewresult. 
        }
    }
}