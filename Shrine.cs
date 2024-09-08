using Discord;
using NadekoBot.Medusa;
using NorthShirahebi;

public sealed class Shrine : Snek
{
    public sealed class SocialInteractions : Snek
    {
        private readonly IImageFetcherService _service;
        private static string UrlHug => "https://waifu.pics/api/sfw/hug";
        private static string UrlPat => "https://waifu.pics/api/sfw/pat";
        private static string UrlKiss => "https://waifu.pics/api/sfw/kiss";
        private static string UrlWave => "https://waifu.pics/api/sfw/wave";
        private static string UrlCuddle => "https://waifu.pics/api/sfw/cuddle";

        public SocialInteractions(IImageFetcherService service)
        {
            _service = service;
        }

        [cmd]
        public async Task Hug(AnyContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            await SendWaifuPicsEmbedAsync(ctx, httpClient, UrlHug, text);
        }

        [cmd]
        public async Task Pat(AnyContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            await SendWaifuPicsEmbedAsync(ctx, httpClient, UrlPat, text);
        }

        [cmd]
        public async Task Kiss(AnyContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            await SendWaifuPicsEmbedAsync(ctx, httpClient, UrlKiss, text);
        }

        [cmd]
        public async Task Wave(AnyContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            await SendWaifuPicsEmbedAsync(ctx, httpClient, UrlWave, text);
        }

        [cmd]
        public async Task Cuddle(AnyContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            await SendWaifuPicsEmbedAsync(ctx, httpClient, UrlCuddle, text);
        }

        private async Task SendWaifuPicsEmbedAsync(AnyContext ctx, [inject] HttpClient httpClient, string url,
            string text)
        {
            var emb = new EmbedBuilder();

            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var img = await _service.GetWaifuPicsImage(url, httpClient);

            if (!string.IsNullOrWhiteSpace(img))
            {
                emb.WithImageUrl(img);
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                emb.WithDescription($"{ctx.User.Mention} cuddled {text}");
            }

            await ctx.Channel.EmbedAsync(emb);
        }
    }

    public sealed class Images : Snek
    {
        private readonly IImageFetcherService _service;

        public Images(IImageFetcherService service)
        {
            _service = service;
        }

        [cmd]
        public async Task Catgirl(AnyContext ctx, [inject] HttpClient httpClient)
        {
            await SendNekosEmbedAsync(ctx, httpClient, ImageFetcherService.Categories.Catgirl);
        }

        [cmd]
        public async Task Rain(AnyContext ctx, [inject] HttpClient httpClient)
        {
            await SendNekosEmbedAsync(ctx, httpClient, ImageFetcherService.Categories.Rain);
        }

        [cmd]
        public async Task Weapon(AnyContext ctx, [inject] HttpClient httpClient)
        {
            await SendNekosEmbedAsync(ctx, httpClient, ImageFetcherService.Categories.Weapon);
        }

        [cmd]
        public async Task Mountain(AnyContext ctx, [inject] HttpClient httpClient)
        {
            await SendNekosEmbedAsync(ctx, httpClient, ImageFetcherService.Categories.Mountain);
        }

        [cmd]
        public async Task Sportswear(AnyContext ctx, [inject] HttpClient httpClient)
        {
            await SendNekosEmbedAsync(ctx, httpClient, ImageFetcherService.Categories.Sportswear);
        }

        [cmd]
        public async Task Baggyclothes(AnyContext ctx, [inject] HttpClient httpClient)
        {
            await SendNekosEmbedAsync(ctx, httpClient, ImageFetcherService.Categories.BaggyClothes);
        }

        [cmd]
        public async Task Dress(AnyContext ctx, [inject] HttpClient httpClient)
        {
            await SendNekosEmbedAsync(ctx, httpClient, ImageFetcherService.Categories.Dress);
        }

        [cmd]
        public async Task Tree(AnyContext ctx, [inject] HttpClient httpClient)
        {
            await SendNekosEmbedAsync(ctx, httpClient, ImageFetcherService.Categories.Tree);
        }
        
        private async Task SendNekosEmbedAsync(AnyContext ctx, [inject] HttpClient httpClient, ImageFetcherService.Categories category)
        {
            var emb = new EmbedBuilder();

            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var img = await _service.GetRandomNekosImage((int)category, httpClient);


            if (!string.IsNullOrWhiteSpace(img))
            {
                emb.WithImageUrl(img);
            }

            await ctx.Channel.EmbedAsync(emb);
        }
    }
}