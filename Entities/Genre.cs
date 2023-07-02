namespace webAPI_EF.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //Relationship: Has Many : Many relationship with Movie
        public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
