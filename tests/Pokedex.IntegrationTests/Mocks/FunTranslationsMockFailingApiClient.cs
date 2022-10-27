﻿using Pokedex.Data.HttpClients;
using Pokedex.Data.Models.FunTranslationsApi;

namespace Pokedex.IntegrationTests.Mocks
{
    public class FunTranslationsMockFailingApiClient : IFunTranslationsApiClient
    {
        public Task<string> GetTranslation(string? textToTranslate, TranslationType translationType)
        {
            throw new Exception("Too many requests!");
        }
    }
}
