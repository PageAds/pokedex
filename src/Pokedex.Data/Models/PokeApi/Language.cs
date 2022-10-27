using Newtonsoft.Json;

namespace Pokedex.Data.Models.PokeApi
{
    public class Language
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}