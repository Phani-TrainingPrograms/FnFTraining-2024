using BlazorWebAssembly.Client;

namespace BlazorWebAssembly.Services
{
    public interface ISimpleService
    {
        string GetName();
    }

    public class SimpleService : ISimpleService
    {
        private readonly IConfiguration _configuration;
        public SimpleService(IConfiguration config)
        {
            _configuration = config;    
        }
        public string GetName() => _configuration.GetSection("MySettings").GetValue<string>("name");
    }
}
