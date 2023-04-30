using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lr5_Tebenko_Andrew_309
{
    internal class WeatherHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://api.weatherstack.com";
        private readonly string _apiKey = "b34e25e957f6fd5885675b94c9802fff";

        public WeatherHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Response> GetCurrent(string cityName)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/current?access_key={_apiKey}&query={cityName}");

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new Response
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }

                var content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<Response>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                data.StatusCode = (int)response.StatusCode;

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while making the request: {ex.Message}");
                return new Response
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<Response> Post(string path, Dictionary<string, string> parameters)
        {
            try
            {
                var content = new FormUrlEncodedContent(parameters);
                var response = await _httpClient.PostAsync($"{_baseUrl}/{path}?access_key={_apiKey}", content);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new Response
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<Response>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                data.StatusCode = (int)response.StatusCode;

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error of request: {ex.Message}");
                return new Response
                {
                    StatusCode = 500
                };
            }
        }
    }
}