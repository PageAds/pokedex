using Newtonsoft.Json;
using Pokedex.Data.Models.FunTranslationsApi;

namespace Pokedex.Data.HttpClients
{
    public class FunTranslationsApiClient : IFunTranslationsApiClient
    {
        private readonly HttpClient httpClient;

        public FunTranslationsApiClient(HttpClient httpClient)
        {
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
                throw new Exception();

            var funTranslationsResponse = JsonConvert.DeserializeObject<FunTranslationsResponse>(responseString);

            return funTranslationsResponse?.Contents?.Translated;
        }
    }
}
