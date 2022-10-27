using Pokedex.Data.Models.FunTranslationsApi;

namespace Pokedex.Data.HttpClients
{
    public interface IFunTranslationsApiClient
    {
        Task<string> GetTranslation(string? textToTranslate, TranslationType translationType);
    }
}
