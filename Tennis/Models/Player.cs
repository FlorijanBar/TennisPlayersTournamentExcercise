using System.ComponentModel.DataAnnotations;

namespace Tennis.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public int Age {  get; set; }
        public required string Country {  get; set; }

        public int? CoachId {  get; set; }
        public Coach? Coach { get; set; }
    }
}
