using Microsoft.EntityFrameworkCore;
using System.Reflection;
using webAPI_EF.Entities;
using webAPI_EF.Entities.Seeding;

namespace webAPI_EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Genre>().Property(g => g.Name).HasMaxLength(150);

            //modelBuilder.Entity<Actor>().Property(a => a.Name).HasMaxLength(150);
            modelBuilder.Entity<Actor>().Property(a => a.DateOfBirth).HasColumnType("date");
            modelBuilder.Entity<Actor>().Property(a => a.Fortune).HasPrecision(18, 2);

            //modelBuilder.Entity<Movie>().Property(m => m.Title).HasMaxLength(150);
            modelBuilder.Entity<Movie>().Property(a => a.ReleaseDate).HasColumnType("date");

            modelBuilder.Entity<Comment>().Property(p => p.Content).HasMaxLength(500);

            base.OnModelCreating(modelBuilder);

            //To read from/see the files in the Configurations folder
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //To parse the Seed Data
            InitialSeedData.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }

    }


}
