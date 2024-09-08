using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TuneAPiano.Models;
namespace TuneAPiano.API
{
    public class GenreAPI
    {
        public static void Map(WebApplication app)
        {
            //Get all Genres
            app.MapGet("/genres", (TuneAPianoDbContext db, IMapper mapper) => 
            {
                var genres = db.Genres.ToList();
                var data = mapper.Map<List<GenreDTO>>(genres);
                return Results.Ok(data);

            });

            //Create a Genre
            app.MapPost("/genres", (TuneAPianoDbContext db, IMapper mapper, GenreDTO newGenreDto) =>
            {
                var newGenre = mapper.Map<Genre>(newGenreDto); try
                {
                    db.Genres.Add(newGenre);
                    db.SaveChanges();
                    return Results.Created($"/genres/{newGenre.Id}", newGenre);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Results.BadRequest("an error occured trying to add a new genre to the database");
                }
            });

            //Delete a Genre
            app.MapDelete("/genres/{id}", (TuneAPianoDbContext db, int id) =>
            {

                var genreToDelete = db.Genres.FirstOrDefault(g => g.Id == id);

                if(genreToDelete == null)
                {
                    Results.NotFound("genre id not found");
                }

                var songGenreToDelete = db.SongsGenres.Where(sg => sg.GenreId == id).ToList();

                db.SongsGenres.RemoveRange(songGenreToDelete);
                db.Genres.Remove(genreToDelete);
                db.SaveChanges();
                return Results.Ok("Genre deleted");

            });

            //Update a Genre
            app.MapPut("/genres/{id}", (TuneAPianoDbContext db, int id, IMapper mapper, GenreDTO updateGenre) =>
            {

                var genre = db.Genres.FirstOrDefault(g =>g.Id ==id);

                if(genre== null)
                {
                    return Results.NotFound("genre not found");
                }

                mapper.Map(updateGenre, genre);

                try
                {
                    db.SaveChanges();
                    return Results.Ok(genre);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("An error occured trying to update the genre in the Database");
                }

            });

            //View a Genre, and all songs with it
            app.MapGet("/genre/{id}/songs", async (TuneAPianoDbContext db, int id) =>
            {

                var genre = await db.Genres.FirstOrDefaultAsync(g => g.Id == id);

                if (genre == null)
                {
                    return Results.NotFound("genre not found");
                }

                var genreSongs = await db.SongsGenres
                    .Where(sg => sg.GenreId == id)
                    .Include(sg => sg.Song)
                    .Select(sg => sg.Song)
                    .ToListAsync();

                if (!genreSongs.Any())
                {
                    return Results.NotFound("No songs found for this genre");
                }

                return Results.Ok(genreSongs);

            });
        }
    }
}
