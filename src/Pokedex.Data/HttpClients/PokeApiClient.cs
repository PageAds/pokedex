using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pokedex.Common.Exceptions;
using Pokedex.Data.Models.PokeApi;
using System.Net;

namespace Pokedex.Data.HttpClients
{
    public class PokeApiClient : IPokeApiClient
    {
        private readonly ILogger<PokeApiClient> logger;
        private readonly HttpClient httpClient;

        public PokeApiClient(
            ILogger<PokeApiClient> logger,
            HttpClient httpClient)
        {
            this.logger = logger;
            this.httpClient = httpClient;
        }

        public async Task<PokemonSpeciesResponse> GetPokemonSpecies(string pokemonName)
        {
            var httpResponseMessage = await httpClient.GetAsync(@$"pokemon-specis/{pokemonName}");

            if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                logger.LogError($"Could not find pokemon: {pokemonName} using  GET {httpResponseMessage?.RequestMessage?.RequestUri}");
                throw new EntityNotFoundException();
            }

            var responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                logger.LogError($"Request: {httpResponseMessage?.RequestMessage?.Method} {httpResponseMessage?.RequestMessage?.RequestUri} " +
                    $"failed with status code: {httpResponseMessage?.StatusCode} with response content: {responseString}");
                
                throw new Exception("Failed to get pokemon species");
            }

            return JsonConvert.DeserializeObject<PokemonSpeciesResponse>(responseString);
        }
    }
}
