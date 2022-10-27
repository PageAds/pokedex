namespace Pokedex.Models
{
    public class Pokemon
    {
        /// <summary>
        /// The name of the pokemon
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of the pokemon
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The natural home of the pokemon
        /// </summary>
        public string? Habitat { get; set; }

        /// <summary>
        /// Whether or not the pokemon is of legendary status
        /// </summary>
        public bool IsLegendary { get; set; }
    }
}
