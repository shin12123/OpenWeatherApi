using System.Text;
using Microsoft.AspNetCore.Mvc;
using   OpenWeatherApi.Clients;

namespace OpenWeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase 
    {
        private readonly ILogger<ApiController> logger;
        public ApiController(ILogger<ApiController> logger) { this.logger = logger; }

        [HttpGet("~/ApiController/GETWeatherForFavorites")]
        public async Task <string> GetWeatherForFavorites(long chatId)
        {
            try
            {
                var client = new ApiClient();
                var FavoriteCitiesClient = new FavoriteCitiesClient();
                var favorites = FavoriteCitiesClient.GetFavorites(chatId);
                if (!favorites.Any())
                {
                    return "Вибачте, на жаль в обраних у вас ніяких міст немає! 😔\nВи можете додати їх вписавши команду /addfavorite [місто].";
                }
                var weatherData = new StringBuilder();

                weatherData.AppendLine("Ваш список обраних міст 🌆:");

                foreach (var city in favorites)
                {

                    var result = client.GetWeatherForCity(city);

                    weatherData.Append(result);

                    //var weather = JsonSerializer.Deserialize<OpenWeatherResponse>(result);
                    //weatherData.AppendLine($"- {city}");
                    //weatherData.AppendLine($"🌆 Зараз у {city} {weather.Main.Temp}°C");
                    //weatherData.AppendLine($"Опис: {weather.Weather[0].Description}.\n");

                }

                return weatherData.ToString();
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "Error listing favorites.");
                return "Помилка";
            }

       }

        [HttpGet("~/ApiController/GETWeatherForCity")]
        public async Task<string> GetWeatherForCity(string city)
        {
            try
            {
                var client = new ApiClient();
                var result = client.GetWeatherForCity(city);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error getting weather for city.");
                return "Неправильно введені дані 😔. Спробуйте ще раз!";
            }
        }

        [HttpGet("~/ApiController/GETWeatherForecast")]
        public async Task<string> GetWeatherForecast(string city)
        {
   
                var client = new ApiClient();
                var result = client.GetWeatherForecast(city);
                return result;
         
        }
    }
    }
