using BlazorWebAssembly.Services;

namespace BlazorWebAssembly.Client
{
    //This class is created to have a common point to register all the services that is consumed by the Application. 

    public class Logger
    {
        string dirName = "C:\\MyFnfLogs";
        string fileName = "fnfLogs.txt";

        public void LogMessage(string message)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            var fullPath = Path.Combine(dirName, fileName);
            File.AppendAllText(message, fullPath);
        }

        public static class RegisterServices
        {
            public static void Register(IServiceCollection services, IConfiguration config)
            {
                string baseAddress = config["baseUrl"];
                services.AddScoped<ISimpleService, SimpleService>();
                services.AddScoped<IArithematicService, ArithematicService>();
                services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            }
        }
    }
}
