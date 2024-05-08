namespace Tennis.Models
{
    public class PlayerTournament
    {
        public int Id { get; set; }
        public int playerId { get; set; }
        public Player Player { get; set; }
        public int tournamentId { get;set; }
        public Tournament Tournament { get; set; }
    }
}
