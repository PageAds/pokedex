using Pokedex.Data.HttpClients;
using Pokedex.Data.Models.FunTranslationsApi;

namespace Pokedex.IntegrationTests.Mocks
{
    public class FunTranslationsMockClient : IFunTranslationsApiClient
    {
        public async Task<string> GetTranslation(string? textToTranslate, TranslationType translationType)
        {
            if (textToTranslate == "Lives about one yard underground where it feeds on plant roots. It sometimes appears above ground."
                && translationType == TranslationType.Yoda)
            {
                return await Task.FromResult("On plant roots, lives about one yard underground where it feeds.Above ground, it sometimes appears.");
            }

            if (textToTranslate == "It was created by a scientist after years of horrific gene splicing and DNA engineering experiments."
                && translationType == TranslationType.Yoda)
            {
                return await Task.FromResult("Created by a scientist after years of horrific gene splicing and dna engineering experiments, it was.");
            }

            if (textToTranslate == "Capable of copying an enemy's genetic code to instantly transform itself into a duplicate of the enemy."
                && translationType == TranslationType.Shakespeare)
            {
                return await Task.FromResult("Capable of copying an foe's genetic code to instantly transform itself into a duplicate of the foe.");
            }

            throw new Exception("Translation not found");
        }
    }
}
