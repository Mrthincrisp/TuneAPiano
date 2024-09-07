namespace TuneAPiano.Models
{
    public class ArtistAndSongDTO
    {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Bio { get; set; }
            public int? Age { get; set; }
            public List<SongAndGenreDTO>? Songs { get; set; }

    }
}
