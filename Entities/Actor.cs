namespace webAPI_EF.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public double Fortune { get; set; }

        //Relationship 1:Many with MovieActor
        public HashSet<MovieActor> MoviesActors { get; set; } = new HashSet<MovieActor>();
    }
}
