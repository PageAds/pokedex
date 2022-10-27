using Pokedex.Common.Models;

namespace Pokedex.Services
{
    public interface IPokemonTranslatorService
    {
        Task<Pokemon> TranslatePokemon(string pokemonName);
    }
}