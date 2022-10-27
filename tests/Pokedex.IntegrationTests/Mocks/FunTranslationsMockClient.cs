﻿using Pokedex.Data.HttpClients;
using Pokedex.Data.Models.FunTranslationsApi;

namespace Pokedex.IntegrationTests.Mocks
{
    public class FunTranslationsMockClient : IFunTranslationsApiClient
    {
        public async Task<string> GetTranslation(string? textToTranslate, TranslationType translationType)
        {
            if (textToTranslate == "Its habitat is dark forests and caves. It emits ultrasonic waves from its nose to learn about its surroundings."
                && translationType == TranslationType.Yoda)
            {
                return await Task.FromResult("Dark forests and caves, its habitat is. Ultrasonic waves from its nose to learn about its surroundings, it emits.");
            }

            throw new Exception("Translation not found");
        }
    }
}