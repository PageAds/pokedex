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
                case "diglett":
                    var diglettPokemonSpeciesResponse = new PokemonSpeciesResponse
                    {
                        Name = "diglett",
                        FlavorTextEntries = new List<FlavorTextEntry>()
                        {
                            new FlavorTextEntry
                            {
                                FlavorText = "Lives about one\nyard underground\nwhere it feeds on\fplant roots. It\nsometimes appears\nabove ground.",
                                Language = new Language
                                {
                                    Name = "en"
                                }
                            }
                        },
                        Habitat = new Habitat
                        {
                            Name = "cave"
                        },
                        IsLegendary = false
                    };

                    return await Task.FromResult(diglettPokemonSpeciesResponse);
                case "mewtwo":
                    var mewtwoPokemonSpeciesResponse = new PokemonSpeciesResponse
                    {
                        Name = "mewtwo",
                        FlavorTextEntries = new List<FlavorTextEntry>()
                        {
                            new FlavorTextEntry
                            {
                                FlavorText = "It was created by\na scientist after\nyears of horrific\fgene splicing and\nDNA engineering\nexperiments.",
                                Language = new Language
                                {
                                    Name = "en"
                                }
                            }
                        },
                        Habitat = new Habitat
                        {
                            Name = "rare"
                        },
                        IsLegendary = true
                    };

                    return await Task.FromResult(mewtwoPokemonSpeciesResponse);
                default:
                    throw new EntityNotFoundException("Pokemon does not exist");
            }
        }
    }
}
