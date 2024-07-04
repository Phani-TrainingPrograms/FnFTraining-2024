using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ensure that U have added the packages of Microsoft.Extensions.Configuration and Microsoft.Extensions.Configuration.Json

namespace FrameworkExamples.Utils
{
    static class AppSettings
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static void Initialize()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath("C:\\Trainings\\FnfTraining\\FnFTraining-2024\\DotnetTraining\\FrameworkExamples")
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();
            if (Configuration == null)
            {
                Configuration = config;
            }
        }
    }
}
