using BlazorWebAssembly;
using BlazorWebAssembly.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using static BlazorWebAssembly.Client.Logger;

namespace BlazorWebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            RegisterServices.Register(builder.Services, builder.Configuration);
            MySettings settings = builder.Configuration.GetValue<MySettings>("MySettings");
            
            await builder.Build().RunAsync();
        }
    }
}