using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        HttpClient _client;
        string _appSettings;

        public OpenWeatherMapAPI(HttpClient client, string appSettings)
        {
            _client = client;
            _appSettings = appSettings;
        }

        public string GetCurrentWeather()
        {

            var ApiKey = JObject.Parse(_appSettings).GetValue("ApiKey").ToString();

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?lat=25.664700&lon=-100.310890&appid={ApiKey}&units=Imperial";

            var weatherInfo = _client.GetStringAsync(weatherURL).Result;

            var weatherMain = JObject.Parse(weatherInfo).GetValue("main").ToString();

            return weatherMain;
        }

        public string GetCurrentCountry()
        {

            var ApiKey = JObject.Parse(_appSettings).GetValue("ApiKey").ToString();

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?lat=25.664700&lon=-100.310890&appid={ApiKey}&units=Imperial";

            var weatherInfo = _client.GetStringAsync(weatherURL).Result;

            var weatherCountry = JObject.Parse(weatherInfo).GetValue("sys").ToString();

            return weatherCountry;
        }

        public string GetCurrentCity()
        {

            var ApiKey = JObject.Parse(_appSettings).GetValue("ApiKey").ToString();

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?lat=25.664700&lon=-100.310890&appid={ApiKey}&units=Imperial";

            var weatherInfo = _client.GetStringAsync(weatherURL).Result;

            var weatherCity = JObject.Parse(weatherInfo).GetValue("name").ToString();

            return weatherCity;
        }

        public IWeather SetCurrentWeather()
        {

            var weather = new Weather();

            var currentWeather = GetCurrentWeather();

            weather.CurrentTemp = JObject.Parse(currentWeather).GetValue("temp").ToString();

            weather.FeelsTemp = JObject.Parse(currentWeather).GetValue("feels_like").ToString();

            weather.MinTemp = JObject.Parse(currentWeather).GetValue("temp_min").ToString();

            weather.MaxTemp = JObject.Parse(currentWeather).GetValue("temp_max").ToString();

            weather.Pressure = JObject.Parse(currentWeather).GetValue("pressure").ToString();

            weather.Humidity = JObject.Parse(currentWeather).GetValue("humidity").ToString();

            return weather;
        }

        public ILocation SetCurrentLocation()
        {
            var location = new Location();

            var currentCountry = GetCurrentCountry();
            var currentCity = GetCurrentCity();

            location.Country = JObject.Parse(currentCountry).GetValue("country").ToString();

            location.City = currentCity;

            return location;
        }

        public void DisplayWeather()
        {
            var weather = SetCurrentWeather();
            var location = SetCurrentLocation();

            Console.SetCursorPosition(Console.WindowWidth / 4, 0);
            Console.WriteLine($"{location.City},{location.Country}");
            Console.WriteLine();
            Console.WriteLine($"In {location.City} right now the temperature is {weather.CurrentTemp}°");
            Console.WriteLine($"It feels like {weather.FeelsTemp}°");
            Console.WriteLine($"You can except temperatures from {weather.MinTemp}° to {weather.MaxTemp}°");
            Console.WriteLine($"With an humidity of {weather.Humidity}%");
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth / 4) - 2, 7);
            Console.WriteLine("Have a great day!");
        }
    }
}
