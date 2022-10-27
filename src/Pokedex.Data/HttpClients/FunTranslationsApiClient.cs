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

        public Task<string> GetTranslation(string? textToTranslate, TranslationType translationType)
        {
            throw new NotImplementedException();
        }
    }
}
