using Pokedex.Data.Handlers;
using Pokedex.Data.HttpClients;
using Pokedex.Data.Repositories;
using Pokedex.Services;

namespace Pokedex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IPokemonRepository, PokemonRepository>();
            builder.Services.AddTransient<IPokemonTranslatorService, PokemonTranslatorService>();
            builder.Services.AddTransient<UnsuccessfulStatusCodeLoggerHandler>();

            builder.Services.AddHttpClient<IPokeApiClient, PokeApiClient>((httpClient) =>
            {
                httpClient.BaseAddress = new Uri(builder.Configuration["PokeApiBaseUrl"]);
            })
            .AddHttpMessageHandler<UnsuccessfulStatusCodeLoggerHandler>();

            builder.Services.AddHttpClient<IFunTranslationsApiClient, FunTranslationsApiClient>((httpClient) =>
            {
                httpClient.BaseAddress = new Uri(builder.Configuration["FunTranslationsApiBaseUrl"]);
            })
            .AddHttpMessageHandler<UnsuccessfulStatusCodeLoggerHandler>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}