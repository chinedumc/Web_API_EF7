using Microsoft.EntityFrameworkCore;

namespace webAPI_EF.Entities.Seeding
{
    public class InitialSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var samelLJackson = new Actor()
            {
                Id = 2,
                Name = "Samuel L. Jackson",
                DateOfBirth = new DateTime(1948, 12, 21),
                Fortune = 15000
            };

            var robertDowneyJunior = new Actor()
            {
                Id = 3,
                Name = "Robert Downey Jr.",
                DateOfBirth = new DateTime(1965, 4, 4),
                Fortune = 15000
            };

            modelBuilder.Entity<Actor>().HasData(samelLJackson, robertDowneyJunior);

            var avengers = new Movie()
            {
                Id = 1,
                Title = "Avengers Endgame",
                ReleaseDate = new DateTime(2019, 4, 22)
            };

            var spiderManNWH = new Movie()
            {
                Id = 2,
                Title = "Spider-Man: No Way Home",
                ReleaseDate = new DateTime(2021, 12, 13)
            };

            var spiderManSpiderVerse2 = new Movie()
            {
                Id = 3,
                Title = "Spider-Man: Across the Spider-Verse (Part One)",
                ReleaseDate = new DateTime(2022, 10, 07)
            };

            modelBuilder.Entity<Movie>().HasData(avengers, spiderManNWH, spiderManSpiderVerse2);

            var avengersComment = new Comment()
            {
                Id = 2,
                Recommend = true,
                Content = "Very good!",
                MovieId = avengers.Id,
            };

            var avengersComment2 = new Comment()
            {
                Id = 3,
                Recommend = true,
                Content = "Great",
                MovieId = avengers.Id,
            };

            var NWHComment = new Comment()
            {
                Id = 4,
                Recommend = false,
                Content = "Just there",
                MovieId = spiderManNWH.Id,
            };

            modelBuilder.Entity<Comment>().HasData(avengersComment, avengersComment2, NWHComment);

            //Many : Many Relationship without a middle-/intermediate table
            var tableMovieGenre = "GenreMovie";
            var genreIdProperty = "GenresId";
            var movieIdProperty = "MoviesId";

            //var biography = 4;
            var scienceFiction = 4;
            var animation = 5;

            modelBuilder.Entity(tableMovieGenre).HasData(
                new Dictionary<string, object>
                {
                    [genreIdProperty] = scienceFiction,
                    [movieIdProperty] = avengers.Id
                },
                
                new Dictionary<string, object>
                {
                    [genreIdProperty] = scienceFiction,
                    [movieIdProperty] = spiderManNWH.Id
                },
                
                new Dictionary<string, object>
                {
                    [genreIdProperty] = animation,
                    [movieIdProperty] = spiderManSpiderVerse2.Id
                }
                );


            //Many : Many with an intermediate table
            var samuelLJacksonSpiderManNWH = new MovieActor
            {
                ActorId = samelLJackson.Id,
                MovieId = spiderManNWH.Id,
                Order = 1,
                Character = "Nick Fury"
            };

            var samuelLJacksonAvengers = new MovieActor
            {
                ActorId = samelLJackson.Id,
                MovieId = avengers.Id,
                Order = 2,
                Character = "Nick Fury"
            };

            var robertDowneyJAvengers = new MovieActor
            {
                ActorId = robertDowneyJunior.Id,
                MovieId = avengers.Id,
                Order = 1,
                Character = "Iron Man"
            };

            modelBuilder.Entity<MovieActor>()
                .HasData(samuelLJacksonSpiderManNWH, samuelLJacksonAvengers, robertDowneyJAvengers);
        }
    }
}
