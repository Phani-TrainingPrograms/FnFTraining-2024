using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Models;
/*
Ajax is a capability of refreshing parts of the page instead of the whole page.
Usually pages are transfered using HTTP. Here we use Xml Http Requests(XHR) for transfering content based on Xml Elements. Using XHR will make parts of the page to go for processing instead of the whole Http page. This makes U look like Single Page Applications(SPA). 
Ajax uses JavaScript for performing the Requests and Responses. 
Data will be in the form of XML, JSON or Plain Text. JSON is the std format of data transfer.  
In ASP.NET, we can use jQuery to perform XHR requests. Using jquery, we make calls to the URLs that return data instead of views or pages. The Front End app will use jQUery/Other HTML tools to dynamically generate the HTML Elements to display the data without a need to refresh the page. 
The URLs that give data instead of HTML Pages are called as REST API/RestFull Services. Frameworks like Express, Springboot, Php, WebAPI can be used in their respective technologies and Programming languages to create such RESTful Services. 
As the services are HTTP based Endpoints, they are platform independent and language independent. 
JS does not have IO Features. For all IO related operations we use Server side Programming(ASP, JSP, PHP, ASP.NET, Spring, EXPRESS/NODEJS) and for UI we use client side programming(JS with Libraries and Frameworks(React, Angular, NextJs, jQuery), Python)
 */
namespace SampleMvcApp.Controllers
{
    /// <summary>
    /// The purpose of this controller is to provide the APIs for accessing and fetching data to the Front End. 
    /// </summary>
    public class MovieDbController : Controller
    {
        private readonly EmployeeDbContext _DbContext;
        public MovieDbController(EmployeeDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public JsonResult AllMovies()
        {
            var movieList = _DbContext.Movies.ToList();
            return Json(movieList);
        }

        public JsonResult Find(string title)
        {
            var movie = _DbContext.Movies.FirstOrDefault(m => m.Title == title);
            return Json(movie);
        }

        [HttpPost]
        public string AddMovie(Movie movie)
        {
           _DbContext.Movies.Add(movie);
            _DbContext.SaveChanges();
            return "Movie saved to the database";
        }

        [HttpPut]
        public string UpdateMovie(Movie movie)
        {
            var found = _DbContext.Movies.Where(m =>m.MovieId == movie.MovieId).FirstOrDefault();
            if (found == null)
            {
                throw new Exception("Not found");
            }
            found.Title = movie.Title;
            found.Actors = movie.Actors;
            found.Description = movie.Description;
            found.Director = movie.Director;
            found.Duration = movie.Duration;
            _DbContext.SaveChanges();
            return "Movie Updated to the database";
        }
    }
}
