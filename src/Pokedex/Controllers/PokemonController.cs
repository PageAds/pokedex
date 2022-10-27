using Microsoft.AspNetCore.Mvc;
using Pokedex.Common.Exceptions;
using Pokedex.Common.Models;
using Pokedex.Data.Repositories;
using Pokedex.Services;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository pokemonRepository;
        private readonly IPokemonTranslatorService pokemonTranslatorService;

        public PokemonController(
            IPokemonRepository pokemonRepository,
            IPokemonTranslatorService pokemonTranslatorService)
        {
            this.pokemonRepository = pokemonRepository;
            this.pokemonTranslatorService = pokemonTranslatorService;
        }

        [HttpGet("{pokemonName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        public async Task<IActionResult> Get(string pokemonName)
        {
            try
            {
                var pokemon = await pokemonRepository.Get(pokemonName);
                return Ok(pokemon);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("translated/{pokemonName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Pokemon))]
        public async Task<IActionResult> GetTranslated(string pokemonName)
        {
            try
            {
                var pokemon = await pokemonTranslatorService.TranslatePokemon(pokemonName);
                return Ok(pokemon);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}