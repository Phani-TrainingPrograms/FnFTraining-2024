using CrudEmployeeApp.Models;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace CrudEmployeeApp.Services
{
    public interface IEmpService
    {
        Task<List<Employee>>GetAll();
        Task<Employee> GetById(int id);

        Task<List<Employee>> GetByName(string name);    
        Task<HttpResponseMessage> AddEmployee(Employee employee); 
        Task<HttpResponseMessage> DeleteEmployee(int id);
        Task<HttpResponseMessage> UpdateEmployee(Employee employee); 
    }

    public class CrudEmployeeService : IEmpService
    {
        private HttpClient _httpClient;
        public CrudEmployeeService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<HttpResponseMessage> AddEmployee(Employee employee)
        {
            //convert the employee to json data
            var json = JsonSerializer.Serialize(employee);
            //create a String content out of json
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //call httpClient's post method. 
            return await _httpClient.PostAsync("", content);
        }

        public async Task<HttpResponseMessage> DeleteEmployee(int id)
        {
            return await _httpClient.DeleteAsync($"{id}");
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>("AllEmployees");
        }

        public async Task<Employee> GetById(int id)
        {
            var content = await _httpClient.GetAsync($"AllEmployees/{id}");
            var data = await content.Content.ReadFromJsonAsync<Employee>();
            return data;
        }

        public async Task<List<Employee>> GetByName(string name)
        {
            var data = await this.GetAll();
            data = data.FindAll(e =>e.EmpName.Contains(name));
            return data;
        }

        public Task<HttpResponseMessage> UpdateEmployee(Employee employee)
        {
            return _httpClient.PutAsJsonAsync<Employee>("", employee);
        }
    }
}