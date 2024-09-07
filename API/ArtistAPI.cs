using TuneAPiano.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace TuneAPiano.API
{
    public class ArtistAPI
    {
        public static void Map(WebApplication app)
        {
            //get all Artists
            app.MapGet("/artists", (TuneAPianoDbContext db) =>
            {
                return Results.Ok(db.Artists);
            });

            //delete an Artist
           app.MapDelete("/artists/{id}", (TuneAPianoDbContext db, int id) =>
            {
                var artistToDelete = db.Artists.Include(a => a.Songs).SingleOrDefault(a => a.Id == id);

                if (artistToDelete == null)
                {
                    return Results.NotFound("Artist not found.");
                }

                // Find or create the placeholder artist
                var placeholderArtist = db.Artists.SingleOrDefault(a => a.Name == "No Artist");
                if (placeholderArtist == null)
                {
                    placeholderArtist = new Artist
                    {
                        Name = "No Artist",
                        Age = 0,
                        Bio = "",
                        Songs = new List<Song>()
                    };
                    db.Artists.Add(placeholderArtist);
                    db.SaveChanges();
                }

                // Reassign songs to the placeholder artist
                foreach (var song in artistToDelete.Songs)
                {
                    song.ArtistId = placeholderArtist.Id; // Assuming Song has an ArtistId FK property
                }

                db.Artists.Remove(artistToDelete);
                db.SaveChanges();
                return Results.Ok("Artist Deleted and songs reassigned to 'No Artist'.");
            });

            //Create an Artist
            app.MapPost("/artists", (TuneAPianoDbContext db, IMapper mapper, NewArtistDTO newArtistDto) =>
            {

                var newArtist = mapper.Map<Artist>(newArtistDto);

                try
                {
                    db.Artists.Add(newArtist);
                    db.SaveChanges();
                    return Results.Created($"/artist/{newArtist.Id}", newArtist);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Results.BadRequest("an error occured trying to add a new artist to the database");
                }

            });

            //Get single Artist and songs
            app.MapGet("/artists/{id}", async (TuneAPianoDbContext db, IMapper mapper, int id) =>
            {

                var artist = await db.Artists
                    .Where(a => a.Id == id)
                    .Include(a => a.Songs).ThenInclude(s => s.SongGenres).ThenInclude(sg => sg.Genre)
                    .SingleOrDefaultAsync();

                if (artist == null)
                {
                    return Results.NotFound("Artist not found");
                }

                var data = mapper.Map<ArtistAndSongDTO>(artist);
                return Results.Ok(data);

            });

            //Update an Artist
            app.MapPut("/artists/{id}", (TuneAPianoDbContext db, IMapper mapper, ArtistDTO updateArtist, int id) =>
            {

                var artist = db.Artists.FirstOrDefault(a => a.Id == id);

                if (artist == null)
                {
                    return Results.NotFound("artist not found, sucks to suck.");
                }
                mapper.Map(updateArtist, artist);

                try
                {
                    db.SaveChanges();
                    return Results.Ok(artist);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("An error occured trying to update the artist; sucks to suck.");
                };

            });
        }
    }
}
