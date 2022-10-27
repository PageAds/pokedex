using Pokedex.Data.Models.PokeApi;

namespace Pokedex.Data.HttpClients
{
    public interface IPokeApiClient
    {
        Task<PokemonSpeciesResponse> GetPokemonSpecies(string pokemonName);
    }
}
