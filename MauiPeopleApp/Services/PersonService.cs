using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using MauiPeopleApp.Models;

namespace MauiPeopleApp.Services
{
    public class PersonService
    {
        private readonly HttpClient _httpClient;

        public PersonService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "reqres-free-v1");
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ApiResponse>("https://reqres.in/api/users?page=1");
                return response?.Data ?? new List<Person>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error fetching people: {ex.Message}");
                return new List<Person>();
            }
        }
        private class ApiResponse
        {
            public List<Person> Data { get; set; }
        }
    }
}