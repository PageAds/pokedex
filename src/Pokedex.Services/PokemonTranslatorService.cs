using Microsoft.Extensions.Logging;
using Pokedex.Common.Models;
using Pokedex.Data.HttpClients;
using Pokedex.Data.Models.FunTranslationsApi;
using Pokedex.Data.Repositories;

namespace Pokedex.Services
{
    public class PokemonTranslatorService : IPokemonTranslatorService
    {
        private readonly ILogger<PokemonTranslatorService> logger;
        private readonly IPokemonRepository pokemonRepository;
        private readonly IFunTranslationsApiClient funTranslationApiClient;

        public PokemonTranslatorService(
            ILogger<PokemonTranslatorService> logger,
            IPokemonRepository pokemonRepository,
            IFunTranslationsApiClient funTranslationApiClient)
        {
            this.logger = logger;
            this.pokemonRepository = pokemonRepository;
            this.funTranslationApiClient = funTranslationApiClient;
        }

        public async Task<Pokemon> TranslatePokemon(string pokemonName)
        {
            var pokemon = await pokemonRepository.Get(pokemonName);

            try
            {
                if (ShouldPerformYodaTranslation(pokemon))
                    pokemon.Description = await funTranslationApiClient.GetTranslation(pokemon.Description, TranslationType.Yoda);
                else
                    pokemon.Description = await funTranslationApiClient.GetTranslation(pokemon.Description, TranslationType.Shakespeare);
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Unable to perform translation of description, using standard description instead");
            }

            return pokemon;
        }

        private static bool ShouldPerformYodaTranslation(Pokemon pokemon)
        {
            if (pokemon.Habitat == null)
                return false;

            return pokemon.Habitat.Equals("cave", StringComparison.OrdinalIgnoreCase) 
                || pokemon.IsLegendary;
        }
    }
}
