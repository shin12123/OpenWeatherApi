using API.Server.Models;
using RestSharp;
using System.Text;
using Newtonsoft.Json;

namespace OpenWeatherApi.Clients
{
    public class ApiClient
    {
        private readonly string _weatherApiKey = "f3f21388ddb8cc4f5f1feefee83f939d";
        
      

        RestClient Client;
        public ApiClient() { Client = new RestClient(); }

        public string GetWeatherForCity(string city)
        {
            try
            {
                var request = new RestRequest($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_weatherApiKey}&units=metric", Method.Get);
                request.AddHeader("x-rapidapi-key", "f3f21388ddb8cc4f5f1feefee83f939d");
                request.AddHeader("x-rapidapi-host", "api.openweathermap.org");
                var content = Client.Execute(request, Method.Get);
                var result = content.Content;

                if (content.IsSuccessful)
                {
                    var weather = JsonConvert.DeserializeObject<OpenWeatherResponse>(result);

                    if (weather != null && weather.Main != null && weather.Weather != null && weather.Weather.Count > 0)
                    {
                        return $"<b>🌆 Погода в {city}:</b>\n<b>Температура:</b> {weather.Main.Temp}°C\n<b>Опис:</b> {weather.Weather[0].Description}.\n";
                    }
                    else
                    {
                        return $"Не вдалося обробити дані про погоду для міста {city} 😔. Спробуйте ще раз пізніше.";
                    }
                }
                else
                {
                    return $"Виникла помилка при отриманні даних про погоду для міста {city} 😔. Код помилки: {content.StatusCode}";
                }
            }
            catch (Exception ex)
            {

                return "Неправильно введені дані 😔. Спробуйте ще раз!";
            }
        }

        public string GetWeatherForecast(string city)
        {
            try
            {
                var request = new RestRequest($"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_weatherApiKey}&units=metric");
                request.AddHeader("x-rapidapi-key", "f3f21388ddb8cc4f5f1feefee83f939d");
                request.AddHeader("x-rapidapi-host", "api.openweathermap.org");
                var content = Client.Execute(request, Method.Get);
                var result = content.Content;

                if (content.IsSuccessful)
                {
                    var weatherForecast = JsonConvert.DeserializeObject<WeatherForecastResponse>(result);

                    var sb = new StringBuilder();
                    sb.AppendLine($"<b>🌆 Прогноз погоди в {city}:</b>");
                    foreach (var forecast in weatherForecast.List)
                    {
                        sb.AppendLine($"{forecast.Dt_txt}: {forecast.Main.Temp}°C, {forecast.Weather[0].Description} {GetWeatherEmoji(forecast.Weather[0].Description)}");
                        if (forecast.Dt_txt.Contains("21:00:00"))
                        {
                            sb.AppendLine();
                        }
                    }
                    return sb.ToString();
                }

                return "Не вдалося отримати дані про прогноз погоди 🌧️.";
            }
            catch (Exception ex)
            {

                return "Неправильно введені дані 😔. Спробуйте ще раз!";
            }

        }

        private string GetWeatherEmoji(string description)
        {
            return description.Contains("rain") ? "🌧️" :
                   description.Contains("cloud") ? "☁️" :
                   description.Contains("clear") ? "☀️" :
                   description.Contains("snow") ? "❄️" :
                   "🌈";
        }

    }
}

