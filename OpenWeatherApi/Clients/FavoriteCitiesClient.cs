using Newtonsoft.Json;

namespace  OpenWeatherApi.Clients
{
    public class FavoriteCitiesClient
    {
        private const string FilePath = "favorites.json";
       
        public void AddFavorite(long chatId, string city)
        {
            Dictionary<long, List<string>> userFavorites = LoadFavoritesFromFile();
            if (!userFavorites.ContainsKey(chatId))
            {
                userFavorites[chatId] = new List<string>();
            }
            if (!userFavorites[chatId].Contains(city))
            {
                userFavorites[chatId].Add(city);
                SaveFavoritesToFile(userFavorites);
            }
        }

        public void RemoveFavorite(long chatId, string city)
        {
            Dictionary<long, List<string>> userFavorites = LoadFavoritesFromFile();
            if (userFavorites.ContainsKey(chatId) && userFavorites[chatId].Contains(city))
            {
                userFavorites[chatId].Remove(city);
                SaveFavoritesToFile(userFavorites);
            }
        }
        public List<string> GetFavorites(long chatId)
        {
            Dictionary<long, List<string>> userFavorites;
            userFavorites = LoadFavoritesFromFile();
            return userFavorites.ContainsKey(chatId) ? userFavorites[chatId] : new List<string>();
        }
        private void SaveFavoritesToFile(Dictionary<long, List<string>> userFavorites)
        {
            var json = JsonConvert.SerializeObject(userFavorites);
            File.WriteAllText(FilePath, json);
        }

        private Dictionary<long, List<string>> LoadFavoritesFromFile()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<Dictionary<long, List<string>>>(json) ?? new Dictionary<long, List<string>>();
            }
            return new Dictionary<long, List<string>>();
        }
    }
}
