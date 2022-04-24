using Nadeko.Snake;
using NadekoBot;
using Newtonsoft.Json;
using north_shirahebi;

public sealed class MySnek : Snek
{
    
    [cmd]
    public async Task hug(GuildContext ctx, [Leftover] string text = null)
    {
        HttpClient httpClient = new HttpClient();
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
        public async Task pat(GuildContext ctx, [Leftover] string text = null)
        {
            HttpClient httpClient = new HttpClient();
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
        public async Task kiss(GuildContext ctx, [Leftover] string text = null)
        {
            HttpClient httpClient = new HttpClient();
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
