using Pokedex.Common.Exceptions;
using Pokedex.Data.HttpClients;
using Pokedex.Data.Models.PokeApi;

namespace Pokedex.IntegrationTests.Mocks
{
    public class PokeApiMockClient : IPokeApiClient
    {
        public async Task<PokemonSpeciesResponse> GetPokemonSpecies(string pokemonName)
        {
            switch (pokemonName)
            {
                case "ditto":
                    var dittoPokemonSpeciesResponse = new PokemonSpeciesResponse
                    {
                        Name = "ditto",
                        FlavorTextEntries = new List<FlavorTextEntry>()
                        {
                            new FlavorTextEntry
                            {
                                FlavorText = "Capable of copying\nan enemy's genetic\ncode to instantly\ftransform itself\ninto a duplicate\nof the enemy.",
                                Language = new Language
                                {
                                    Name = "en"
                                }
                            }
                        },
                        Habitat = new Habitat
                        {
                            Name = "urban"
                        },
                        IsLegendary = false
                    };

                    return await Task.FromResult(dittoPokemonSpeciesResponse);
                default:
                    throw new EntityNotFoundException("Pokemon does not exist");
            }
        }
    }
}
