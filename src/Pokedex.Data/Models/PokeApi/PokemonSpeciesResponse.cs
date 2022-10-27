using Newtonsoft.Json;

namespace Pokedex.Data.Models.PokeApi
{
    public class PokemonSpeciesResponse
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("flavor_text_entries")]
        public IEnumerable<FlavorTextEntry>? FlavorTextEntries { get; set; }

        [JsonProperty("habitat")]
        public Habitat? Habitat { get; set; }

        [JsonProperty("is_legendary")]
        public bool IsLegendary { get; set; }
    }
}
