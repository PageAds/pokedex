using Newtonsoft.Json;

namespace Pokedex.Data.Models.FunTranslationsApi
{
    public class Contents
    {
        [JsonProperty("translated")]
        public string? Translated { get; set; }
    }
}