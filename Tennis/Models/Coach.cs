using System.ComponentModel.DataAnnotations;

namespace Tennis.Models
{
    public class Coach
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }

        public ICollection<Player>? Players { get; set; }

    }
}
