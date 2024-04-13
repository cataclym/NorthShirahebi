using System.Text.Json.Serialization;

namespace NorthShirahebi;

public class NekosData
{
    [JsonPropertyName("items")] public List<Datum> Data { get; set; }
}

public class Datum
{
    [JsonPropertyName("image_url")] public string Url { get; set; }
}