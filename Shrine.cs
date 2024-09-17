using System.Net.Http.Json;
using Discord;
using NadekoBot.Medusa;

namespace NorthShirahebi;

public sealed class Shrine : Snek
{
    public new string Name = "Shrine";
    private static readonly HttpClient Client = new HttpClient();
    
    [svc(Lifetime.Singleton)]
    public sealed class ShrineService
    {
        public async Task<string> GetWaifuPicsImage(ImageType imageType)
        {
            var img = await Client
                .GetFromJsonAsync<WaifuData>($"https://waifu.pics/api/sfw/{imageType}")
                .ConfigureAwait(false);
        
            return img.URL;
        }
        
        public async Task SendWaifuPicsEmbedAsync(AnyContext ctx, ImageType imageType, string text)
        {
            var emb = new EmbedBuilder();

            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var img = await GetWaifuPicsImage(imageType);

            if (!string.IsNullOrWhiteSpace(img))
            {
                emb.WithImageUrl(img);
            }

            switch(imageType)
            {
                case ImageType.hug:
                    emb.WithDescription($"{ctx.User.Mention} hugged {text}");
                    break;
                case ImageType.pat:
                    emb.WithDescription($"{ctx.User.Mention} petted {text}");
                    break;
                case ImageType.kiss:
                    emb.WithDescription($"{ctx.User.Mention} kissed {text}");
                    break;
                case ImageType.wave:
                    emb.WithDescription($"{ctx.User.Mention} waved to {text}");
                    break;
                case ImageType.cuddle:
                    emb.WithDescription($"{ctx.User.Mention} cuddled {text}");
                    break;
            }
    
            await ctx.Channel.EmbedAsync(emb);
        }
        
        public async Task SendWaifuPicsEmbedAsync(AnyContext ctx, ImageType imageType)
        {
            var emb = new EmbedBuilder();

            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var img = await GetWaifuPicsImage(imageType);

            if (!string.IsNullOrWhiteSpace(img))
            {
                emb.WithImageUrl(img);
            }

            await ctx.Channel.EmbedAsync(emb);
        }
    }
    
    public enum ImageType  
    {
        hug,
        pat,
        kiss,
        wave,
        cuddle,
        waifu,
        neko,
        shinobu,
        megumin
    }
    
    public sealed class SocialInteractions(ShrineService service) : Snek
    {
        [cmd]
        public async Task Hug(AnyContext ctx, [leftover] string text = null)
        {
            await service.SendWaifuPicsEmbedAsync(ctx, ImageType.hug, text);
        }

        [cmd]
        public async Task Pat(AnyContext ctx, [leftover] string text = null)
        {
            await service.SendWaifuPicsEmbedAsync(ctx, ImageType.pat, text);
        }

        [cmd]
        public async Task Kiss(AnyContext ctx, [leftover] string text = null)
        {
            await service.SendWaifuPicsEmbedAsync(ctx, ImageType.kiss, text);
        }

        [cmd]
        public async Task Wave(AnyContext ctx, [leftover] string text = null)
        {
            await service.SendWaifuPicsEmbedAsync(ctx, ImageType.wave, text);
        }

        [cmd]
        public async Task Cuddle(AnyContext ctx, [leftover] string text = null)
        {
            await service.SendWaifuPicsEmbedAsync(ctx, ImageType.cuddle, text);
        }
    }

    public sealed class Images(ShrineService service) : Snek
    {
        [cmd]
        public async Task Waifu(AnyContext ctx)
        {
            await service.SendWaifuPicsEmbedAsync(ctx, ImageType.waifu);
        }

        [cmd]
        public async Task Neko(AnyContext ctx)
        {
            await service.SendWaifuPicsEmbedAsync(ctx, ImageType.neko);
        }

        [cmd]
        public async Task Shinobu(AnyContext ctx)
        {
            await service.SendWaifuPicsEmbedAsync(ctx, ImageType.shinobu);
        }
        
        [cmd]
        public async Task Megumin(AnyContext ctx)
        {
            await service.SendWaifuPicsEmbedAsync(ctx, ImageType.megumin);
        }

    }
}