namespace TuneAPiano.Models
{
    public class NewSongDTO
    {
        public string? Title { get; set; }
        public string? Album { get; set; }
        public int Length { get; set; }
        public int? ArtistId { get; set; }
        public List<int>? GenreIds { get; set; }
    }
}
