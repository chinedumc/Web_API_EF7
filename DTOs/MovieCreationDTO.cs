namespace webAPI_EF.DTOs
{
    public class MovieCreationDTO
    {
        public string Title { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public bool InTheatres { get; set; }
        public List<int> Genres { get; set; } = new List<int>();
        public List<MovieActorCreationDTO> MoviesActors { get; set; } = new List<MovieActorCreationDTO>();
    }

    public class MovieActorCreationDTO
    {
        public int ActorId { get; set; }
        public string Character { get; set; } = null!;
    }

}
