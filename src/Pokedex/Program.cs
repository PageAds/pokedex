using Pokedex.Data.HttpClients;
using Pokedex.Data.Repositories;

namespace Pokedex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IPokemonRepository, PokemonRepository>();

            builder.Services.AddHttpClient<IPokeApiClient, PokeApiClient>((httpClient) =>
            {
                httpClient.BaseAddress = new Uri(builder.Configuration["PokeApiBaseUrl"]);
            });

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