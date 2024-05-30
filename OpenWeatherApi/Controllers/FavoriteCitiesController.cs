using Microsoft.AspNetCore.Mvc;
using OpenWeatherApi.Clients;

namespace OpenWeatherApi.Controllers
    
{
    [ApiController]
    [Route("controller")]
    public class FavoriteCitiesController
    {
        private const string FilePath = "favorites.json";
        private readonly ILogger <FavoriteCitiesController>logger;
        public FavoriteCitiesController(ILogger<FavoriteCitiesController> logger)
        {
         
            this.logger = logger;
        }

        [HttpGet("~/FavoriteCitiesController/GETfavorites")]
        public List<string> GetFavorites(long chatId)
        {
            var FavoriteCitiesClient = new FavoriteCitiesClient();
            return FavoriteCitiesClient.GetFavorites(chatId);
        }

        [HttpPut("~/FavoriteCitiesController/ADDfavorite")]
        public void AddFavorite(long chatId, string city)
        {
            var FavoriteCitiesClient = new FavoriteCitiesClient();
            FavoriteCitiesClient.AddFavorite(chatId, city);
            return;
        }

        [HttpDelete("~/FavoriteCitiesController/REMOVEfavorite")]
        public void RemoveFavorite(long chatId, string city)
        {
            var FavoriteCitiesClient = new FavoriteCitiesClient();
            FavoriteCitiesClient.RemoveFavorite(chatId, city);
            return;
        }
    }

    public class FavoriteCity
    {
        public long ChatId { get; set; }
        public List<string> Cities { get; set; } = new List<string>();
    }
}
