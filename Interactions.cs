using Nadeko.Snake;
using NadekoBot;
using Newtonsoft.Json;
using NorthShirahebi;

public sealed class Interactions : Snek
{
    
    [cmd]
    public async Task Hug(GuildContext ctx, [inject] HttpClient httpClient, [leftover] string text = null)
    {
        IEmbedBuilder emb = ctx.Embed().WithOkColor();
           
            await ctx.Channel.TriggerTypingAsync().ConfigureAwait(false);
            using (var http = httpClient)
            {
                var img = await http.GetAsync("https://waifu.pics/api/sfw/hug").ConfigureAwait(false);
                var content = await img.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<WaifuData>(content);
                if (data != null) emb.WithImageUrl(data.URL);
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

            using (var http = httpClient)
            {
                var img = await http.GetAsync("https://waifu.pics/api/sfw/pat").ConfigureAwait(false);
                var content = await img.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<WaifuData>(content);
                if (data != null) emb.WithImageUrl(data.URL);
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

            using (var http = httpClient)
            {
                var img = await http.GetAsync("https://waifu.pics/api/sfw/kiss").ConfigureAwait(false);
                var content = await img.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<WaifuData>(content);
                if (data != null) emb.WithImageUrl(data.URL);
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                emb.WithDescription($"{ctx.User.Mention} kissed {text}");
            }

            await ctx.Channel.EmbedAsync(emb);
        }
}
