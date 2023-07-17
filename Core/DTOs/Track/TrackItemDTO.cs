namespace Core.DTOs.Track
{
    public class TrackItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Track { get; set; }
        public string Image { get; set; }
        public bool? IsDeleted { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}