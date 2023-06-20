using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter a city: ");
            string city = Console.ReadLine();

            await GetWeather(city);
        }

        static async Task GetWeather(string city)
        {
            string apiKey = "6c497a6a7abefc6e7cd66d455a304fbc"; // Replace with your OpenWeatherMap API key
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(apiUrl);
                JObject obj = JObject.Parse(json);

                string weather = (string)obj["weather"][0]["main"];
                string description = (string)obj["weather"][0]["description"];
                double temperature = (double)obj["main"]["temp"];

                Console.WriteLine($"Weather in {city}: {weather} ({description}). Temperature: {temperature}°C.");
            }
        }
    }
}
