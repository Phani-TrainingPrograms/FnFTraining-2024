
using Microsoft.EntityFrameworkCore;
using WebApiCore.Data;
using WebApiCore.Services;

namespace WebApiCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Perform Scafolding, refer the Github for Db-Scafold syntax. 
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Add the DBContext to the DI pipeline.
            builder.Services.AddDbContext<FnfTrainingContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"));
            });
            //Next Step: Create a Folder called Dtos and create the DTO classes as per the Table structure we have. 
            
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            //Next Step: Implement the controller with the required DI service.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
