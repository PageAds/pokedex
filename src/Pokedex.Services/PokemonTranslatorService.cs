using Pokedex.Common.Models;
using Pokedex.Data.HttpClients;
using Pokedex.Data.Models.FunTranslationsApi;
using Pokedex.Data.Repositories;

namespace Pokedex.Services
{
    public class PokemonTranslatorService : IPokemonTranslatorService
    {
        private readonly IPokemonRepository pokemonRepository;
        private readonly IFunTranslationsApiClient funTranslationApiClient;

        public PokemonTranslatorService(
            IPokemonRepository pokemonRepository,
            IFunTranslationsApiClient funTranslationApiClient)
        {
            this.pokemonRepository = pokemonRepository;
            this.funTranslationApiClient = funTranslationApiClient;
        }

        public async Task<Pokemon> TranslatePokemon(string pokemonName)
        {
            var pokemon = await pokemonRepository.Get(pokemonName);

            if (ShouldPerformYodaTranslation(pokemon))
                pokemon.Description = await funTranslationApiClient.GetTranslation(pokemon.Description, TranslationType.Yoda);

            return pokemon;
        }

        private static bool ShouldPerformYodaTranslation(Pokemon pokemon)
        {
            if (pokemon.Habitat == null)
                return false;

            return pokemon.Habitat.Equals("cave", StringComparison.OrdinalIgnoreCase);
        }
    }
}
