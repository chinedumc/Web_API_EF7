namespace webAPI_EF.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public bool InTheatres { get; set; }

        //Relationship with Comments is 1: Many
        public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();

        //Relationship Many : Many with Genre
        public HashSet<Genre> Genres { get; set; } = new HashSet<Genre>();

        //Relationship 1:Many with MovieActor
        public List<MovieActor> MoviesActors { get; set; } = new List<MovieActor>();

    }
}
