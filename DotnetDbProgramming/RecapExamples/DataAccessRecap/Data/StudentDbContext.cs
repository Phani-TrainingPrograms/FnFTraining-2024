using DataAccessRecap.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//In ORM, the data will be retrieved and stored in the collection. U read the data from the collection. U add new data into the collection and then save the changes to update it to the actual database. Similarly, U do it for update and delete operations 
namespace DataAccessRecap.Data
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } //Represents the actual data retrieved from the database. 

        public IConfigurationRoot? Configuration { get; set; }

        private void ConfigureServices()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath("C:\\Trainings\\FnfTraining\\RecapExamples\\DataAccessRecap")
                .AddJsonFile("appsettings.json", false)
                .Build();
            if (Configuration == null)
            {
                Configuration = config;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            ConfigureServices();
            if (Configuration != null)
            {
                var connectionstring = Configuration["connectionString"];
                if (connectionstring == null)
                {
                    throw new ApplicationException("Could not read from the Configuration file");
                }
                optionsBuilder.UseSqlServer(connectionstring);
            }
            else
            {
                throw new Exception("Configuration is not set for the Dll");
            }
        }
    }
}
