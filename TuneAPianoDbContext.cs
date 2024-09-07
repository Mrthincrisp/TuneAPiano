namespace TuneAPiano;

using Microsoft.EntityFrameworkCore;
using TuneAPiano.Models;

    public class TuneAPianoDbContext : DbContext
    {
        public DbSet<Artist>? Artists { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Song>? Songs { get; set; }
        public DbSet<SongGenre>? SongsGenres { get; set; }


        public TuneAPianoDbContext(DbContextOptions<TuneAPianoDbContext> context) : base(context)
        {



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Artists
            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "Ludwig van Beethoven", Age = 56, Bio = "A German composer and pianist, a crucial figure in the transition between the classical and romantic eras in classical music." },
                new Artist { Id = 2, Name = "Wolfgang Amadeus Mozart", Age = 35, Bio = "A prolific and influential composer of the classical era, born in Salzburg." },
                new Artist { Id = 3, Name = "Frederic Chopin", Age = 39, Bio = "A Polish composer and virtuoso pianist of the Romantic era, known for his solo piano compositions." },
                new Artist { Id = 4, Name = "Johann Sebastian Bach", Age = 65, Bio = "A German composer and musician of the Baroque period, known for instrumental compositions such as the Brandenburg Concertos." },
                new Artist { Id = 5, Name = "Claude Debussy", Age = 55, Bio = "A French composer, a prominent figure in the impressionist music movement." }
            );

        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Description = "Classical" },
            new Genre { Id = 2, Description = "Romantic" },
            new Genre { Id = 3, Description = "Baroque" },
            new Genre { Id = 4, Description = "Impressionist" },
            new Genre { Id = 5, Description = "Modern" }
        );

        // Seed data for Songs
        modelBuilder.Entity<Song>().HasData(
            new Song { Id = 1, Title = "Symphony No. 5", ArtistId = 1, Album = "Beethoven: Symphonies", Length = 425 },
            new Song { Id = 2, Title = "Moonlight Sonata", ArtistId = 1, Album = "Beethoven: Piano Sonatas", Length = 900 },
            new Song { Id = 3, Title = "Eine kleine Nachtmusik", ArtistId = 2, Album = "Mozart: Serenades", Length = 360 },
            new Song { Id = 4, Title = "Requiem", ArtistId = 2, Album = "Mozart: Requiem", Length = 1800 },
            new Song { Id = 5, Title = "Nocturne in E-flat Major", ArtistId = 3, Album = "Chopin: Nocturnes", Length = 290 },
            new Song { Id = 6, Title = "Prelude in D-flat Major", ArtistId = 3, Album = "Chopin: Preludes", Length = 270 },
            new Song { Id = 7, Title = "Toccata and Fugue in D minor", ArtistId = 4, Album = "Bach: Organ Works", Length = 540 },
            new Song { Id = 8, Title = "Brandenburg Concerto No. 3", ArtistId = 4, Album = "Bach: Brandenburg Concertos", Length = 1190 },
            new Song { Id = 9, Title = "Clair de Lune", ArtistId = 5, Album = "Debussy: Suite bergamasque", Length = 300 },
            new Song { Id = 10, Title = "La Mer", ArtistId = 5, Album = "Debussy: Orchestral Works", Length = 1200 },
            new Song { Id = 11, Title = "Symphony No. 9", ArtistId = 1, Album = "Beethoven: Symphonies", Length = 4500 },
            new Song { Id = 12, Title = "Don Giovanni", ArtistId = 2, Album = "Mozart: Operas", Length = 7200 }
        );

        // Seed data for SongGenres
        modelBuilder.Entity<SongGenre>().HasData(
            // Symphony No. 5
            new SongGenre { Id = 1, SongId = 1, GenreId = 1 }, // Classical
            new SongGenre { Id = 2, SongId = 1, GenreId = 3 }, // Baroque

            // Moonlight Sonata
            new SongGenre { Id = 3, SongId = 2, GenreId = 1 }, // Classical
            new SongGenre { Id = 4, SongId = 2, GenreId = 2 }, // Romantic

            // Eine kleine Nachtmusik
            new SongGenre { Id = 5, SongId = 3, GenreId = 1 }, // Classical
            new SongGenre { Id = 6, SongId = 3, GenreId = 2 }, // Romantic

            // Requiem
            new SongGenre { Id = 7, SongId = 4, GenreId = 1 }, // Classical
            new SongGenre { Id = 8, SongId = 4, GenreId = 2 }, // Romantic
            new SongGenre { Id = 9, SongId = 4, GenreId = 3 }, // Baroque

            // Nocturne in E-flat Major
            new SongGenre { Id = 10, SongId = 5, GenreId = 1 }, // Classical
            new SongGenre { Id = 11, SongId = 5, GenreId = 2 }, // Romantic

            // Prelude in D-flat Major
            new SongGenre { Id = 12, SongId = 6, GenreId = 1 }, // Classical
            new SongGenre { Id = 13, SongId = 6, GenreId = 2 }, // Romantic

            // Toccata and Fugue in D minor
            new SongGenre { Id = 14, SongId = 7, GenreId = 3 }, // Baroque
            new SongGenre { Id = 15, SongId = 7, GenreId = 4 }, // Impressionist

            // Brandenburg Concerto No. 3
            new SongGenre { Id = 16, SongId = 8, GenreId = 3 }, // Baroque
            new SongGenre { Id = 17, SongId = 8, GenreId = 4 }, // Impressionist

            // Clair de Lune
            new SongGenre { Id = 18, SongId = 9, GenreId = 4 }, // Impressionist
            new SongGenre { Id = 19, SongId = 9, GenreId = 5 }, // Modern

            // La Mer
            new SongGenre { Id = 20, SongId = 10, GenreId = 4 }, // Impressionist
            new SongGenre { Id = 21, SongId = 10, GenreId = 5 }, // Modern

            // Symphony No. 9
            new SongGenre { Id = 22, SongId = 11, GenreId = 1 }, // Classical
            new SongGenre { Id = 23, SongId = 11, GenreId = 2 }, // Romantic

            // Don Giovanni
            new SongGenre { Id = 24, SongId = 12, GenreId = 1 } // Classical
        );



modelBuilder.Entity<Song>()
    .HasMany(s => s.SongGenres) 
    .WithOne(sg => sg.Song)     
    .HasForeignKey(sg => sg.SongId) 
    .OnDelete(DeleteBehavior.Cascade);

modelBuilder.Entity<Genre>()
    .HasMany(g => g.SongGenres)  
    .WithOne(sg => sg.Genre)     
    .HasForeignKey(sg => sg.GenreId) 
    .OnDelete(DeleteBehavior.Restrict);

        }
    }