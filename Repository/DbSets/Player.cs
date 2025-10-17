namespace NbaTracker.Repository.DbSets
{
    public class Player
    {
        public int Id { get; set; } 
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public int Age { get; set; }
        public string? Team { get; set; }
    }
}
