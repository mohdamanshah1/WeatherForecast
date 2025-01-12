namespace WeatherForecast.Models;

public class CurrentWeatherModel
{
    [JsonPropertyName("location")]
    public Location Location { get; set; }

    [JsonPropertyName("current")]
    public Current Current { get; set; }
}

public class Location
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("lat")]
    public float Latitude { get; set; }

    [JsonPropertyName("lon")]
    public float Longitude { get; set; }

    [JsonPropertyName("tz_id")]
    public string TimeZoneId { get; set; }

    [JsonPropertyName("localtime_epoch")]
    public decimal LocaltimeEpoch { get; set; }

    [JsonPropertyName("localtime")]
    public string Localtime { get; set; }
}

public class Current
{
    [JsonPropertyName("last_updated_epoch")]
    public decimal LastUpdatedEpoch { get; set; }

    [JsonPropertyName("last_updated")]
    public string LastUpdated { get; set; }

    [JsonPropertyName("temp_c")]
    public float TemperatureCelsius { get; set; }

    [JsonPropertyName("temp_f")]
    public float TemperatureFahrenheit { get; set; }

    [JsonPropertyName("is_day")]
    public float IsDay { get; set; }

    [JsonPropertyName("condition")]
    public Condition Condition { get; set; }

    [JsonPropertyName("wind_mph")]
    public float WindMph { get; set; }

    [JsonPropertyName("wind_kph")]
    public float WindKph { get; set; }

    [JsonPropertyName("wind_degree")]
    public float WindDegree { get; set; }

    [JsonPropertyName("wind_dir")]
    public string WindDirection { get; set; }

    [JsonPropertyName("pressure_mb")]
    public float PressureMb { get; set; }

    [JsonPropertyName("pressure_in")]
    public float PressureIn { get; set; }

    [JsonPropertyName("precip_mm")]
    public float PrecipitationMm { get; set; }

    [JsonPropertyName("precip_in")]
    public float PrecipitationIn { get; set; }

    [JsonPropertyName("humidity")]
    public float Humidity { get; set; }

    [JsonPropertyName("cloud")]
    public float Cloud { get; set; }

    [JsonPropertyName("feelslike_c")]
    public float FeelsLikeCelsius { get; set; }

    [JsonPropertyName("feelslike_f")]
    public float FeelsLikeFahrenheit { get; set; }

    [JsonPropertyName("windchill_c")]
    public float WindChillCelsius { get; set; }

    [JsonPropertyName("windchill_f")]
    public float WindChillFahrenheit { get; set; }

    [JsonPropertyName("heatindex_c")]
    public float HeatIndexCelsius { get; set; }

    [JsonPropertyName("heatindex_f")]
    public float HeatIndexFahrenheit { get; set; }

    [JsonPropertyName("dewpoint_c")]
    public float DewPointCelsius { get; set; }

    [JsonPropertyName("dewpoint_f")]
    public float DewPointFahrenheit { get; set; }

    [JsonPropertyName("vis_km")]
    public float VisibilityKm { get; set; }

    [JsonPropertyName("vis_miles")]
    public float VisibilityMiles { get; set; }

    [JsonPropertyName("uv")]
    public float UV { get; set; }

    [JsonPropertyName("gust_mph")]
    public float GustMph { get; set; }

    [JsonPropertyName("gust_kph")]
    public float GustKph { get; set; }
}

public class Condition
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("code")]
    public float Code { get; set; }
}
