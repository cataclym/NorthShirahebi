using System.Net.Http.Json;
using Nadeko.Snake;

namespace NorthShirahebi;

[svc(Lifetime.Singleton)]
public sealed class ImageFetcherService : IImageFetcherService
{
    private readonly IReadOnlySet<string> _validInputs = new HashSet<string>()
    {
        "8",
        "28",
        "30",
        "22",
        "4",
        "39",
        "35",
        "33",
        
        // "Catgirl",
        // "Rain",
        // "Weapon",
        // "Mountain",
        // "Sportswear",
        // "Baggy clothes",
        // "Dress",
        // "Tree",
    };

    public async Task<string> GetWaifuPicsImage(string url, HttpClient http)
    {
        var img = await http.GetFromJsonAsync<WaifuData>(url).ConfigureAwait(false);
        return img?.URL ?? "https://i.waifu.pics/YEG4YAl.gif";
    }

    public async Task<string> GetRandomNekosImage(string category, HttpClient http)
    {
        if (!_validInputs.Contains(category)) throw new ArgumentOutOfRangeException(nameof(category));

        var data = await http.GetFromJsonAsync<NekosData>(
            $"https://v1.nekosapi.com/api/image/random?categories={category}&limit=1");

        return data.Data[0].Url;
    }
}

public interface IImageFetcherService
{
    Task<string> GetWaifuPicsImage(string url, HttpClient http);
    Task<string> GetRandomNekosImage(string category, HttpClient http);
}