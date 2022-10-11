using Nadeko.Snake;
using NadekoBot;
using Newtonsoft.Json;
using NorthShirahebi;

public sealed class Interactions : Snek
{
    private static string UrlHug => "https://waifu.pics/api/sfw/hug";
    private static string UrlPat => "https://waifu.pics/api/sfw/pat";
    private static string UrlKiss => "https://waifu.pics/api/sfw/kiss";
    private static string UrlWave => "https://waifu.pics/api/sfw/wave";
    private static string UrlCuddle => "https://waifu.pics/api/sfw/cuddle";
        
        
        [cmd]
        public async Task Hug(GuildContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            IEmbedBuilder emb = ctx.Embed().WithOkColor();
           
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var img = await GetImage(UrlHug, httpClient);
            
            if (!string.IsNullOrWhiteSpace(img))
            {
                emb.WithImageUrl(img);
            }

            
            if (!string.IsNullOrWhiteSpace(text))
            {
                emb.WithDescription($"{ctx.User.Mention} hugged {text}");
            }

            await ctx.Channel.EmbedAsync(emb);
        }
            
        [cmd]
        public async Task Pat(GuildContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            IEmbedBuilder emb = ctx.Embed()
                .WithOkColor();
           
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var img = await GetImage(UrlPat, httpClient);
            
            if (!string.IsNullOrWhiteSpace(img))
            {
                emb.WithImageUrl(img);
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                emb.WithDescription($"{ctx.User.Mention} patted {text}");
            }

            await ctx.Channel.EmbedAsync(emb);
        }
        
        [cmd]
        public async Task Kiss(GuildContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            IEmbedBuilder emb = ctx.Embed()
                .WithOkColor();
           
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var img = await GetImage(UrlKiss, httpClient);
            
            if (!string.IsNullOrWhiteSpace(img))
            {
                emb.WithImageUrl(img);
            }
            
            if (!string.IsNullOrWhiteSpace(text))
            {
                emb.WithDescription($"{ctx.User.Mention} kissed {text}");
            }

            await ctx.Channel.EmbedAsync(emb);
        }
        
        [cmd]
        public async Task Wave(GuildContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            IEmbedBuilder emb = ctx.Embed()
                .WithOkColor();
           
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var img = await GetImage(UrlWave, httpClient);
            
            if (!string.IsNullOrWhiteSpace(img))
            {
                emb.WithImageUrl(img);
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                emb.WithDescription($"{ctx.User.Mention} waved at {text}");
            }

            await ctx.Channel.EmbedAsync(emb);
        }
        
        [cmd]
        public async Task Cuddle(GuildContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
        {
            IEmbedBuilder emb = ctx.Embed()
                .WithOkColor();
           
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var img = await GetImage(UrlCuddle, httpClient);
            
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

        private async Task<string> GetImage(String url, HttpClient http)
        {
            var img = await http.GetAsync(url).ConfigureAwait(false);
            var content = await img.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<WaifuData>(content);
            return data?.URL ?? "https://i.waifu.pics/YEG4YAl.gif";
        }
}
