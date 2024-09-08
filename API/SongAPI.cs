using TuneAPiano.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace TuneAPiano.API
{
    public class SongAPI
    {
        public static void Map(WebApplication app)
        {
            // Add a new Song
            app.MapPost("/songs", (TuneAPianoDbContext db, IMapper mapper, NewSongDTO newSongDto) =>
            {
                var newSong = mapper.Map<Song>(newSongDto);

                newSong.SongGenres = newSongDto.GenreIds.Select(genreId => new SongGenre
                {
                    GenreId = genreId,
                    Song = newSong
                }).ToList();

                try
                {
                    db.Songs.Add(newSong);
                    db.SaveChanges();
                    return Results.Created($"/songs/{newSong.Id}", newSong);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("An error occurred trying to add a new song to the database.");
                }
            });

            // Update a song
            app.MapPut("/songs/{id}", (TuneAPianoDbContext db, IMapper mapper, int id, SongDTO updateSongDto) =>
            {

                var song = db.Songs.FirstOrDefault(s => s.Id == id);

                if (song == null)
                {
                    return Results.NotFound("song id not found, song is null");
                }
                mapper.Map(updateSongDto, song);

                try
                {
                    db.SaveChanges();
                    return Results.Ok(song);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("An error occured trying to update the song in the database.");
                }


            });

            // Delete a song
            app.MapDelete("/songs/{id}", (TuneAPianoDbContext db, int id) =>
            {
                var songToDelete = db.Songs.FirstOrDefault(s => s.Id == id);

                if(songToDelete == null)
                {
                    return Results.NotFound("No song with matching id");
                }

                db.Songs.Remove(songToDelete);
                db.SaveChanges();
                return Results.Ok("Song deleted");
            });

            //Get all Songs
            app.MapGet("/songs", (TuneAPianoDbContext db) =>
            {

                return Results.Ok(db.Songs);

            });

            //Get a song with genres and artist
            app.MapGet("/songs/{id}", async (TuneAPianoDbContext db, IMapper mapper, int id) =>
            {

                var song = await db.Songs
                .Where(s => s.Id == id)
                .Include(s => s.Artist)
                .Include(s => s.SongGenres).ThenInclude(sg => sg.Genre)
                .SingleOrDefaultAsync();

                if (song == null)
                {
                    return Results.NotFound("song is null");
                }

                var songDto = mapper.Map<SongDTO>(song);
                return Results.Ok(songDto);

            });

            //Get songs by genre
            app.MapGet("/songs/genre/{id}", (TuneAPianoDbContext db, int id) =>
            {

                var song = db.SongsGenres
                    .Where(sg => sg.GenreId == id)
                    .Include(sg => sg.Song)
                    .ToList();

                return Results.Ok(song);

            });

            //Get entities by string input
            app.MapGet("songs/artists/genres/{input}", async (TuneAPianoDbContext db, string input) =>
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return Results.BadRequest("Search term cannot be empty.");
                }

                var lowerCaseInput = input.ToLower();

                var matchingSong = await db.Songs
                    .Where(s => s.Title.ToLower().Contains(lowerCaseInput))
                    .ToListAsync();

                var matchingArtist = await db.Artists
                    .Where(a => a.Name.ToLower().Contains(lowerCaseInput))
                    .ToListAsync();

                var matchingGenre = await db.Genres
                    .Where(g => g.Description.ToLower().Contains(lowerCaseInput))
                    .ToListAsync();


                return Results.Ok(new
                {
                    Songs = matchingSong,
                    Artists = matchingArtist,
                    Genres = matchingGenre
                });

            });
        }
    }
}
