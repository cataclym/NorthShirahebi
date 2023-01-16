using System.Text.Json.Serialization;

namespace NorthShirahebi;

public class NekosData
{
    [JsonPropertyName("data")] public List<Datum> Data { get; set; }
}

public class Datum
{
    [JsonPropertyName("url")] public string Url { get; set; }
}