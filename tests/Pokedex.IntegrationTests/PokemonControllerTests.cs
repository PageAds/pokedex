using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pokedex.Common.Models;
using Pokedex.Data.HttpClients;
using Pokedex.IntegrationTests.Mocks;
using Shouldly;
using System.Net;
using Xunit;

namespace Pokedex.IntegrationTests
{
    public class PokemonControllerTests
    {
        [Fact]
        public async Task Get_WhenPokemonIsRequested_ReturnsPokemonInformation()
        {
            // Arrange
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services =>
                    {
                        services.AddTransient<IPokeApiClient, PokeApiMockClient>();
                    });
                });

            var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/pokemon/ditto");

            // Assert
            response.ShouldNotBeNull();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var responseString = await response.Content.ReadAsStringAsync();
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(responseString);
            pokemon.ShouldNotBeNull();
            pokemon.Name.ShouldBe("ditto");
            pokemon.Description.ShouldBe("Capable of copying an enemy's genetic code to instantly transform itself into a duplicate of the enemy.");
            pokemon.Habitat.ShouldBe("urban");
            pokemon.IsLegendary.ShouldBeFalse();
        }

        [Fact]
        public async Task Get_WhenPokemonIsRequestedButNotFound_ReturnsHttpStatusCodeNotFound()
        {
            // Arrange
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services =>
                    {
                        services.AddTransient<IPokeApiClient, PokeApiMockClient>();
                    });
                });

            var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/pokemon/unknown-pokemon");

            // Assert
            response.ShouldNotBeNull();
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}