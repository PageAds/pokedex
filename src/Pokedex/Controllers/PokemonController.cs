using Microsoft.AspNetCore.Mvc;
using Pokedex.Common.Models;
using Pokedex.Data.Repositories;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            this.pokemonRepository = pokemonRepository;
        }

        [HttpGet("{pokemonName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
        public async Task<IActionResult> Get(string pokemonName)
        {
            var pokemon = await pokemonRepository.Get(pokemonName);
            return Ok(pokemon);
        }
    }
}