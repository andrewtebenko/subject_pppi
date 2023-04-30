using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lr5_Tebenko_Andrew_309
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var weatherstack = new WeatherHttpClient();

            var response = await weatherstack.GetCurrent("San Francisco");
            if (response.StatusCode == (int)System.Net.HttpStatusCode.OK)
            {
                var weather = response.Current;
                Console.WriteLine(weather);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            Console.ReadLine();
        }
    }
}