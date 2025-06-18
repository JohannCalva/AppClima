using AppClima.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClima.Services
{
    public class WeatherServices
    {
        public async Task<WeatherData> GetWeatherDataFromLocationAsync(double latitude, double longitude)
        {
            string latitude_str = latitude.ToString().Replace(",", ".");
            string longitude_str = longitude.ToString().Replace(",", ".");

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude_str}&longitude={longitude_str}&current=temperature_2m,relative_humidity_2m,rain";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
