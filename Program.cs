using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace csharp_weather
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckLocalWeather().Wait();
        }
        private static async Task CheckLocalWeather()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync("http://api.openweathermap.org/data/2.5/forecast?id=4644585&APPID=");

            var msg = await stringTask;
            Console.WriteLine(msg);
        }
    }
}
