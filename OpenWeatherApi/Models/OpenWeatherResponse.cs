using System.Text.Json.Serialization;

namespace API.Server.Models
{
    public class OpenWeatherResponse
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; } = new Coord();

        [JsonPropertyName("weather")]
        public List<OpenWeatherDescription> Weather { get; set; } = new List<OpenWeatherDescription>();

        [JsonPropertyName("base")]
        public string Base { get; set; } = string.Empty;

        [JsonPropertyName("main")]
        public MainData Main { get; set; } = new MainData();

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; } = new Wind();

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; } = new Clouds();

        [JsonPropertyName("dt")]
        public long Dt { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; } = new Sys();

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }

    public class Coord
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }

    public class OpenWeatherDescription
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
    }

    public class MainData
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public int GrndLevel { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Deg { get; set; }

        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
    }

    public class WeatherForecastResponse
    {
        [JsonPropertyName("list")]
        public List<WeatherForecast> List { get; set; } = new List<WeatherForecast>();
    }

    public class WeatherForecast
    {
        [JsonPropertyName("dt_txt")]
        public string Dt_txt { get; set; } = string.Empty;

        [JsonPropertyName("main")]
        public MainData Main { get; set; } = new MainData();

        [JsonPropertyName("weather")]
        public List<WeatherInfo> Weather { get; set; } = new List<WeatherInfo>();
    }

    public class WeatherInfo
    {
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
    }
}