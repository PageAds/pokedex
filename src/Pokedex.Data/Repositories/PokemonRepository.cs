using Pokedex.Common.Models;
using Pokedex.Data.HttpClients;

namespace Pokedex.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IPokeApiClient pokeApiClient;

        public PokemonRepository(IPokeApiClient pokeApiClient)
        {
            this.pokeApiClient = pokeApiClient;
        }

        public async Task<Pokemon> Get(string pokemonName)
        {
            var pokemonSpeciesResponse = await pokeApiClient.GetPokemonSpecies(pokemonName);

            return new Pokemon
            {
                Name = pokemonSpeciesResponse.Name,
                Description = pokemonSpeciesResponse.FlavorTextEntries?
                    .FirstOrDefault(x => x.Language?.Name == "en")?
                    .FlavorText?
                    .Replace("\n", " ") // Replace line breaks
                    .Replace("\f", " "), // Replace upward arrow
                Habitat = pokemonSpeciesResponse.Habitat?.Name,
                IsLegendary = pokemonSpeciesResponse.IsLegendary
            };
        }
    }
}
