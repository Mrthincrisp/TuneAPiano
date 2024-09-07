﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TuneAPiano;

#nullable disable

namespace TuneAPiano.Migrations
{
    [DbContext(typeof(TuneAPianoDbContext))]
    [Migration("20240907023856_SCascade")]
    partial class SCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TuneAPiano.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 56,
                            Bio = "A German composer and pianist, a crucial figure in the transition between the classical and romantic eras in classical music.",
                            Name = "Ludwig van Beethoven"
                        },
                        new
                        {
                            Id = 2,
                            Age = 35,
                            Bio = "A prolific and influential composer of the classical era, born in Salzburg.",
                            Name = "Wolfgang Amadeus Mozart"
                        },
                        new
                        {
                            Id = 3,
                            Age = 39,
                            Bio = "A Polish composer and virtuoso pianist of the Romantic era, known for his solo piano compositions.",
                            Name = "Frederic Chopin"
                        },
                        new
                        {
                            Id = 4,
                            Age = 65,
                            Bio = "A German composer and musician of the Baroque period, known for instrumental compositions such as the Brandenburg Concertos.",
                            Name = "Johann Sebastian Bach"
                        },
                        new
                        {
                            Id = 5,
                            Age = 55,
                            Bio = "A French composer, a prominent figure in the impressionist music movement.",
                            Name = "Claude Debussy"
                        });
                });

            modelBuilder.Entity("TuneAPiano.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Classical"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Romantic"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Baroque"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Impressionist"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Modern"
                        });
                });

            modelBuilder.Entity("TuneAPiano.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Beethoven: Symphonies",
                            ArtistId = 1,
                            Length = 425,
                            Title = "Symphony No. 5"
                        },
                        new
                        {
                            Id = 2,
                            Album = "Beethoven: Piano Sonatas",
                            ArtistId = 1,
                            Length = 900,
                            Title = "Moonlight Sonata"
                        },
                        new
                        {
                            Id = 3,
                            Album = "Mozart: Serenades",
                            ArtistId = 2,
                            Length = 360,
                            Title = "Eine kleine Nachtmusik"
                        },
                        new
                        {
                            Id = 4,
                            Album = "Mozart: Requiem",
                            ArtistId = 2,
                            Length = 1800,
                            Title = "Requiem"
                        },
                        new
                        {
                            Id = 5,
                            Album = "Chopin: Nocturnes",
                            ArtistId = 3,
                            Length = 290,
                            Title = "Nocturne in E-flat Major"
                        },
                        new
                        {
                            Id = 6,
                            Album = "Chopin: Preludes",
                            ArtistId = 3,
                            Length = 270,
                            Title = "Prelude in D-flat Major"
                        },
                        new
                        {
                            Id = 7,
                            Album = "Bach: Organ Works",
                            ArtistId = 4,
                            Length = 540,
                            Title = "Toccata and Fugue in D minor"
                        },
                        new
                        {
                            Id = 8,
                            Album = "Bach: Brandenburg Concertos",
                            ArtistId = 4,
                            Length = 1190,
                            Title = "Brandenburg Concerto No. 3"
                        },
                        new
                        {
                            Id = 9,
                            Album = "Debussy: Suite bergamasque",
                            ArtistId = 5,
                            Length = 300,
                            Title = "Clair de Lune"
                        },
                        new
                        {
                            Id = 10,
                            Album = "Debussy: Orchestral Works",
                            ArtistId = 5,
                            Length = 1200,
                            Title = "La Mer"
                        },
                        new
                        {
                            Id = 11,
                            Album = "Beethoven: Symphonies",
                            ArtistId = 1,
                            Length = 4500,
                            Title = "Symphony No. 9"
                        },
                        new
                        {
                            Id = 12,
                            Album = "Mozart: Operas",
                            ArtistId = 2,
                            Length = 7200,
                            Title = "Don Giovanni"
                        });
                });

            modelBuilder.Entity("TuneAPiano.Models.SongGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("SongId");

                    b.ToTable("SongsGenres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            SongId = 1
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 3,
                            SongId = 1
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 1,
                            SongId = 2
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 2,
                            SongId = 2
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 1,
                            SongId = 3
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 2,
                            SongId = 3
                        },
                        new
                        {
                            Id = 7,
                            GenreId = 1,
                            SongId = 4
                        },
                        new
                        {
                            Id = 8,
                            GenreId = 2,
                            SongId = 4
                        },
                        new
                        {
                            Id = 9,
                            GenreId = 3,
                            SongId = 4
                        },
                        new
                        {
                            Id = 10,
                            GenreId = 1,
                            SongId = 5
                        },
                        new
                        {
                            Id = 11,
                            GenreId = 2,
                            SongId = 5
                        },
                        new
                        {
                            Id = 12,
                            GenreId = 1,
                            SongId = 6
                        },
                        new
                        {
                            Id = 13,
                            GenreId = 2,
                            SongId = 6
                        },
                        new
                        {
                            Id = 14,
                            GenreId = 3,
                            SongId = 7
                        },
                        new
                        {
                            Id = 15,
                            GenreId = 4,
                            SongId = 7
                        },
                        new
                        {
                            Id = 16,
                            GenreId = 3,
                            SongId = 8
                        },
                        new
                        {
                            Id = 17,
                            GenreId = 4,
                            SongId = 8
                        },
                        new
                        {
                            Id = 18,
                            GenreId = 4,
                            SongId = 9
                        },
                        new
                        {
                            Id = 19,
                            GenreId = 5,
                            SongId = 9
                        },
                        new
                        {
                            Id = 20,
                            GenreId = 4,
                            SongId = 10
                        },
                        new
                        {
                            Id = 21,
                            GenreId = 5,
                            SongId = 10
                        },
                        new
                        {
                            Id = 22,
                            GenreId = 1,
                            SongId = 11
                        },
                        new
                        {
                            Id = 23,
                            GenreId = 2,
                            SongId = 11
                        },
                        new
                        {
                            Id = 24,
                            GenreId = 1,
                            SongId = 12
                        });
                });

            modelBuilder.Entity("TuneAPiano.Models.Song", b =>
                {
                    b.HasOne("TuneAPiano.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TuneAPiano.Models.SongGenre", b =>
                {
                    b.HasOne("TuneAPiano.Models.Genre", "Genre")
                        .WithMany("SongGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TuneAPiano.Models.Song", "Song")
                        .WithMany("SongGenres")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("TuneAPiano.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("TuneAPiano.Models.Genre", b =>
                {
                    b.Navigation("SongGenres");
                });

            modelBuilder.Entity("TuneAPiano.Models.Song", b =>
                {
                    b.Navigation("SongGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
