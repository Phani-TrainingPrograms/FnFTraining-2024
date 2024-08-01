using SampleApiMvcClient.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SampleApiMvcClient.Services
{
    public interface IStockService
    {
        void AddNewStock(Stock stock);
        void DeleteStock(int stockId);
        List<Stock> GetAllStocks();
        Stock GetStockById(int id);
        void UpdateStock(Stock stock);
    }

    /// <summary>
    /// This class implements the services to call the Web API and interact with the data.
    /// </summary>
    public class StockService : IStockService
    {

        //HttpClient is a .NET Class that helps to perform http calls to the RESTfull Services. 
        private readonly HttpClient httpClient;
        public StockService(HttpClient client)
        {
            httpClient = client;
        }
        public List<Stock> GetAllStocks()
        {
            List<Stock>? stocks = new List<Stock>();
            //Get the stream data from the REST API
            var data = httpClient.GetStreamAsync("Stocks").Result;
            //Deserialize the data into List<Stock> with ignoring the Case sensitiveness
            if (data != null)
            {
                stocks = JsonSerializer.DeserializeAsync<List<Stock>>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }).Result;
            }
            return stocks;

        }

        public Stock GetStockById(int id)
        {
            var stock = new Stock();    
            using (var response = httpClient.GetStreamAsync($"Stocks/{id}"))
            {
                var data = response.Result;
                stock = JsonSerializer.DeserializeAsync<Stock>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).Result;
            }
            return stock;
        }

        public void AddNewStock(Stock stock)
        {
            //convert the stock to a json object.
            var json = JsonSerializer.Serialize(stock);
            //convert the json to a httpContent(StringContent)
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //Call the httpPost
            var responseMessage = httpClient.PostAsync("Stocks", content).Result;
            Console.WriteLine(responseMessage.Content.ReadAsStringAsync().Result);
        }

        public void UpdateStock(Stock stock) 
        {
            //REST API data will be in the form of Json
            try
            {
                //Convert it into Json object. 
                var jsonContent = JsonSerializer.Serialize(stock);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var res = httpClient.PutAsync("Stocks", content).Result;
                //Display the response message on the Console Output Window. 
                Console.WriteLine(res.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteStock(int id) 
        {
            var res = httpClient.DeleteAsync($"Stocks/{id}").Result;
            var deletedRec = JsonSerializer.Deserialize<Stock>(res.Content.ReadAsStringAsync().Result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (deletedRec != null)
            {
                Console.WriteLine($"{deletedRec.StockName} is removed Successfully");
            }
        }
    }
}
