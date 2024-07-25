using Microsoft.EntityFrameworkCore;
using SampleMvcApp.Models;

namespace SampleMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //services are independent set of functions(Classes implementing a certain interface) that can be injected into the application so that we can use them whenever we want in the application.
//////////////////////////DBContext Setting///////////////////////////////
            //Use this for MVC and WebAPI for getting Connection string thru Appsettings... 
            builder.Services.AddDbContext<EmployeeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"));
            });
//////////////////////////////////////////////////////////////////////////
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");//Exception handler for all the unhandled Exceptions. Exceptions are supposed to be handled at the respective function levels. 
            }
            app.UseStaticFiles();//Helps in loading static Html pages, CSS files and Client side libraries.

            app.UseRouting();

            app.UseAuthorization();

            //Routing: A pattern of the URL that the User should send for this Application. Controller is the object that performs the operations. Action is a method that fetches the required model and injects the model object into a view and returns that view. 
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Traversing}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
