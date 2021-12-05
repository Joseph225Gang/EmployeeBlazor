using EmployeeBlazor.Entity;
using System.Text;
using System.Text.Json;

namespace EmployeeBlazor
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiPort = "localhost:7034";
        public EmployeeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task AddEmployee(Employee employee)
        {
            var employeeJson =
               new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"https://{apiPort}/api/employee", employeeJson);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _httpClient.DeleteAsync($"https://{apiPort}/api/employee/{employeeId}");
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                   (await _httpClient.GetStreamAsync($"https://{apiPort}/api/employee"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<Employee>
                (await _httpClient.GetStreamAsync($"https://{apiPort}/api/employee/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var employeeJson =
               new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"https://{apiPort}/api/employee", employeeJson);
        }

    }
}
