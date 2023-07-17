namespace Core.DTOs.Album
{
    public class AlbumCreateDTO
    {
        /// <example>Summer album</example>
        public string Title { get; set; }

        /// <example>1</example>
        public int PublisherId { get; set; }

        /// <example>1</example>
        public int GenreId { get; set; }
        public int? UserId { get; set; }

        /// <example>1300</example>
        public int Duration { get; set; }
        public DateTime? DateCreated { get; set; }

        /// <example>INSERT BASE64</example>
        public string Image { get; set; }

        /// <example>The best album for summer</example>
        public string Description { get; set; }

        public bool? IsDeleted { get; set; }

        public bool IsExplicit { get; set; }

        public bool IsPublic { get; set; }
    }
}
