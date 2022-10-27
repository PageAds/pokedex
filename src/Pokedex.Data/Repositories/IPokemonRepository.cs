using Pokedex.Common.Models;

namespace Pokedex.Data.Repositories
{
    public interface IPokemonRepository
    {
        Task<Pokemon> Get(string pokemonName);
    }
}
