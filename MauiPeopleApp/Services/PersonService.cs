using System.Net.Http.Json;
using MauiPeopleApp.Models;

namespace MauiPeopleApp.Services;

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
        // get your api key from https://reqres.in/signup
        var response = await _httpClient.GetFromJsonAsync<ApiResponse>("https://reqres.in/api/users?api_key=reqres-free-v1");
        return response?.Data ?? new List<Person>();
    }

    private class ApiResponse
    {
        public List<Person> Data { get; set; }
    }
}