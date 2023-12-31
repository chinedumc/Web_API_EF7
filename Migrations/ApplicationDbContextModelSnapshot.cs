﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webAPI_EF;

#nullable disable

namespace webAPI_EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");

                    b.HasData(
                        new
                        {
                            GenresId = 4,
                            MoviesId = 1
                        },
                        new
                        {
                            GenresId = 4,
                            MoviesId = 2
                        },
                        new
                        {
                            GenresId = 5,
                            MoviesId = 3
                        });
                });

            modelBuilder.Entity("webAPI_EF.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<double>("Fortune")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortune = 15000.0,
                            Name = "Samuel L. Jackson"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortune = 15000.0,
                            Name = "Robert Downey Jr."
                        });
                });

            modelBuilder.Entity("webAPI_EF.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<bool>("Recommend")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Content = "Very good!",
                            MovieId = 1,
                            Recommend = true
                        },
                        new
                        {
                            Id = 3,
                            Content = "Great",
                            MovieId = 1,
                            Recommend = true
                        },
                        new
                        {
                            Id = 4,
                            Content = "Just there",
                            MovieId = 2,
                            Recommend = false
                        });
                });

            modelBuilder.Entity("webAPI_EF.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Biography"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Animation"
                        });
                });

            modelBuilder.Entity("webAPI_EF.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("InTheatres")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InTheatres = false,
                            ReleaseDate = new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avengers Endgame"
                        },
                        new
                        {
                            Id = 2,
                            InTheatres = false,
                            ReleaseDate = new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: No Way Home"
                        },
                        new
                        {
                            Id = 3,
                            InTheatres = false,
                            ReleaseDate = new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: Across the Spider-Verse (Part One)"
                        });
                });

            modelBuilder.Entity("webAPI_EF.Entities.MovieActor", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MoviesActors");

                    b.HasData(
                        new
                        {
                            ActorId = 2,
                            MovieId = 2,
                            Character = "Nick Fury",
                            Order = 1
                        },
                        new
                        {
                            ActorId = 2,
                            MovieId = 1,
                            Character = "Nick Fury",
                            Order = 2
                        },
                        new
                        {
                            ActorId = 3,
                            MovieId = 1,
                            Character = "Iron Man",
                            Order = 1
                        });
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("webAPI_EF.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webAPI_EF.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webAPI_EF.Entities.Comment", b =>
                {
                    b.HasOne("webAPI_EF.Entities.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("webAPI_EF.Entities.MovieActor", b =>
                {
                    b.HasOne("webAPI_EF.Entities.Actor", "Actor")
                        .WithMany("MoviesActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webAPI_EF.Entities.Movie", "Movie")
                        .WithMany("MoviesActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("webAPI_EF.Entities.Actor", b =>
                {
                    b.Navigation("MoviesActors");
                });

            modelBuilder.Entity("webAPI_EF.Entities.Movie", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("MoviesActors");
                });
#pragma warning restore 612, 618
        }
    }
}
