using System.Text.Json.Serialization;

namespace NorthShirahebi;

public class NekosData
{
    [JsonPropertyName("items")] public List<Datum> Items { get; set; }
}

public class Datum
{
    [JsonPropertyName("image_url")] public string ImageUrl { get; set; }
}