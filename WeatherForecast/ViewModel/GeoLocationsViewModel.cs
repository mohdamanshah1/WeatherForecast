namespace WeatherForecast.ViewModel
{
    public class GeoLocationsViewModel
    {
        [JsonPropertyName("results")]
        public List<GeoLocationModel> Locations { get; set; }
        [JsonPropertyName("generation_time")]
        public decimal GenerationTime { get; set; }
    }
}
