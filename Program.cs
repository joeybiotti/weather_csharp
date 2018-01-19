using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace WxAPP
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
            var serializer = new DataContractJsonSerializer(typeof(List<WxResults>));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync("http://api.openweathermap.org/data/2.5/forecast?id="); //API KEY NEEDED
            var streamTask = client.GetStreamAsync("http://api.openweathermap.org/data/2.5/forecast?id=4644585&APPID="); //API KEY NEEDED

            var weatherResults = serializer.ReadObject(await streamTask) as List<WxResults>;

            foreach(var result in weatherResults)
                Console.WriteLine(result.List);
        }
    }
}
