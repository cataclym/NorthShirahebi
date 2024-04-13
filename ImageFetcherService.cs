using System.Diagnostics;
using System.Net.Http.Json;
using Nadeko.Snake;
using Serilog.Core;

namespace NorthShirahebi;

[svc(Lifetime.Singleton)]
public sealed class ImageFetcherService : IImageFetcherService
{

    public async Task<string> GetWaifuPicsImage(string url, HttpClient http)
    {
        var img = await http.GetFromJsonAsync<WaifuData>(url).ConfigureAwait(false);
        return img?.URL ?? "https://i.waifu.pics/YEG4YAl.gif";
    }

    public async Task<string> GetRandomNekosImage(Categories category, HttpClient http)
    {
        var stringEndPoint = $"https://api.sappiness.com/v3/images/random/file?tag={category}&limit=1"
            Trace.WriteLine(stringEndPoint);
            
        return await http
            .GetStringAsync(stringEndPoint)
            .ConfigureAwait(false);
    }

    public enum Categories
    {
        Catgirl = 8,
        Rain = 28,
        Weapon = 30,
        Mountain = 22,
        Sportswear = 4,
        BaggyClothes = 39,
        Dress = 35,
        Tree = 33
    }
}

public interface IImageFetcherService
{
    Task<string> GetWaifuPicsImage(string url, HttpClient http);
    Task<string> GetRandomNekosImage(ImageFetcherService.Categories category, HttpClient http);
}