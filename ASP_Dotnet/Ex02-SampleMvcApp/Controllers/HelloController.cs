using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Models;

//Controller is a C# Class that implements an interface called IController. However, there is a class called Controller that has the default implementations as per the ASP.NET pipeline which can be used as the base class for all the Controllers.  
namespace SampleMvcApp.Controllers
{
    public class HelloController : Controller
    {
        public string Greeting() => "Hello world from .NET MVC";

        //ViewResult is a class that represents a View. 
        public ViewResult Details()
        {
            var emp = new Employee
            {
               EmpId = 111, 
               EmpName ="Phaniraj",
               EmpAddress ="Bangalore", 
               EmpSalary = 45000,
               EmpImage = "../Images/Phani.png"
            };//Create the model object.
            return View(emp);//Inject the model into View and return it. 
        }
    }
}
