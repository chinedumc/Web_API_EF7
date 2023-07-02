using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace webAPI_EF.Entities.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //builder.Property(g => g.Name).HasMaxLength(150);

            //Adding more Genres 
            var biography = new Genre { Id = 4, Name = "Biography" };
            var scienceFiction = new Genre { Id = 5, Name = "Science Fiction" };
            var animation = new Genre { Id = 6, Name = "Animation" };
            builder.HasData(scienceFiction, biography, animation); //Now, go to PM and add-migration

            builder.HasIndex(p => p.Name).IsUnique(); //If we want unique indices
        }
    }


}
