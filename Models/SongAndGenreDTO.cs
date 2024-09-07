namespace TuneAPiano.Models
{
    public class SongAndGenreDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Album { get; set; }
        public int Length { get; set; }
        public List<GenreDTO>? Genres { get; set; }
    }
}
