using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pokedex.Data.Models.FunTranslationsApi;

namespace Pokedex.Data.HttpClients
{
    public class FunTranslationsApiClient : IFunTranslationsApiClient
    {
        private readonly ILogger<FunTranslationsApiClient> logger;
        private readonly HttpClient httpClient;

        public FunTranslationsApiClient(
            ILogger<FunTranslationsApiClient> logger,
            HttpClient httpClient)
        {
            this.logger = logger;
            this.httpClient = httpClient;
        }

        public async Task<string> GetTranslation(string? textToTranslate, TranslationType translationType)
        {
            string? requestUri;
            switch (translationType)
            {
                case TranslationType.Yoda:
                    requestUri = $"yoda.json?text={textToTranslate}";
                    break;
                case TranslationType.Shakespeare:
                    requestUri = $"shakespeare.json?text={textToTranslate}";
                    break;
                default:
                    throw new Exception($"Translation type not implemented: {translationType}");
            }

            var httpResponseMessage = await httpClient.GetAsync(requestUri);

            var responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new Exception("Failed to get fun translation");

            var funTranslationsResponse = JsonConvert.DeserializeObject<FunTranslationsResponse>(responseString);

            if (funTranslationsResponse?.Contents?.Translated == null)
            {
                logger.LogError($"Unable to determine translated value after deserialization, response content: {responseString}");
               
                throw new Exception("Unable to determine translated value");
            }

            return funTranslationsResponse.Contents.Translated;
        }
    }
}
