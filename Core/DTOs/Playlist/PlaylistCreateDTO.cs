namespace Core.DTOs.Playlist
{
    public class PlaylistCreateDTO
    {
        /// <example>My music for weekend</example>
        public string Title { get; set; }

        /// <example>Simply and calm</example>
        public string Description { get; set; }

        /// <example>2400</example>
        public int Duration { get; set; }

        /// <example>INSERT BASE64</example>
        public string Image { get; set; }

        public bool IsExplicit { get; set; }

        public bool IsPublic { get; set; }
        public int? GenreId { get; set; }
        public int? UserId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
