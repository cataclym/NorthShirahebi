using System.Text.Json.Serialization;

namespace NorthShirahebi;

public class WaifuData
{
    [JsonPropertyName("url")] public string URL { get; set; }
}