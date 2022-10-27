using Newtonsoft.Json;

namespace Pokedex.Data.Models.PokeApi
{
    public class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string? FlavorText { get; set; }

        [JsonProperty("language")]
        public Language? Language { get; set; }
    }
}