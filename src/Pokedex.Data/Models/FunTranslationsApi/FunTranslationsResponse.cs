using Newtonsoft.Json;

namespace Pokedex.Data.Models.FunTranslationsApi
{
    public class FunTranslationsResponse
    {
        [JsonProperty("contents")]
        public Contents? Contents { get; set; }
    }
}
