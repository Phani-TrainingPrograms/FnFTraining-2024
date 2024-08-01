using Microsoft.AspNetCore.Mvc;
//Todo: Send data from the Controller to the View and get the inputs from the View to the Controller without using Models. 
//A View can be associated with only one Kind of Model. U cannot have multiple Models for a View. If the View is already associated with one Model, any additional data could be sent in different ways supported by MVC. 

namespace SampleMvcApp.Controllers
{
    public class TraversingController : Controller
    {
        public IActionResult Index()//LIKE Hyperlinks.....
        {
            var options = new string[] { "Add", "Subtract", "Multiply", "Divide" };
            ViewData["options"] = options;
            return View();
        }

        [HttpPost]//After U give inputs and click SUBMIT.....
        //public IActionResult Index(IFormCollection collection)
        //{
        //    var options = new string[] { "Add", "Subtract", "Multiply", "Divide" };
        //    ViewData["options"] = options;
        //    UsingViewBag(collection);
        //    return View();
        //}
        //Getting the inputs from the View to the controller in the form of Parameters. Each Paraemter is the name of the input element within the form.....
        public IActionResult Index(string firstValue, string secondValue, string slOptions)
        {
            var options = new string[] { "Add", "Subtract", "Multiply", "Divide" };
            ViewData["options"] = options;
            var first = double.Parse(firstValue);
            var second = double.Parse(secondValue);
            var option = slOptions;
            var result = 0.0;
            switch (option)
            {
                case "Add": result = first + second; break;
                case "Subtract": result = first - second; break;
                case "Multiply": result = first * second; break;
                case "Divide": result = first / second; break;
                default: break;
            }
            //Viewbag is one way of sending data to the View...
            ViewBag.Result = result;//It is like a KeyValue pair, where in this case, Result is the key and result is the value. 
            return  View();
        }

        private void UsingViewBag(IFormCollection collection)
        {
            var firstValue = double.Parse(collection["firstValue"]);
            var secondValue = double.Parse(collection["secondValue"]);
            var option = collection["slOptions"];
            var result = 0.0;
            switch (option)
            {
                case "Add": result = firstValue + secondValue; break;
                case "Subtract": result = firstValue - secondValue; break;
                case "Multiply": result = firstValue * secondValue; break;
                case "Divide": result = firstValue / secondValue; break;
                default: break;
            }
            //Viewbag is one way of sending data to the View...
            ViewBag.Result = result;//It is like a KeyValue pair, where in this case, Result is the key and result is the value. 
        }
    }
}

//Ways to send data from the Controller to View: Model, ViewBag, ViewData, TempData. 
//Ways to send data from the View to Controller: Posted Model, IFormCollection, Parameters Collection.  
