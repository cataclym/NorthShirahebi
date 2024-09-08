using System.Diagnostics;
using System.Net.Http.Json;
using NadekoBot.Medusa;
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

    public async Task<string> GetRandomNekosImage(int category, HttpClient http)
    {
        var stringEndPoint = $"https://api.nekosapi.com/v3/images/random?tag={category}&limit=1&rating=safe";
            
        var data = await http
            .GetFromJsonAsync<NekosData>(stringEndPoint)
            .ConfigureAwait(false);

        return data.Items.FirstOrDefault()?.ImageUrl;
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
    Task<string> GetRandomNekosImage(int category, HttpClient http);
}