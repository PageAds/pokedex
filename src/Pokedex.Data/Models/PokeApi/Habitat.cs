using Newtonsoft.Json;

namespace Pokedex.Data.Models.PokeApi
{
    public class Habitat
    {
        [JsonProperty("Name")]
        public string? Name { get; set; }
    }
}