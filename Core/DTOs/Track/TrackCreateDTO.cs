using Microsoft.AspNetCore.Http;

namespace Core.DTOs.Track
{
    public class TrackCreateDTO
    {
        /// <example>Where is my mind?</example>
        public string Title { get; set; }

        /// <example>1</example>
        public int GenreId { get; set; }

        /// <example>It's a song by the American alternative rock band Pixies.</example>
        public string Description { get; set; }

        /// <example>180</example>
        public int? Duration { get; set; }

        /// <example>INSERT BASE64</example>
        public string Image { get; set; }

        public bool IsExplicit { get; set; }
        public bool IsPublic { get; set; }
        public IFormFile Track { get; set; }
        public bool? IsDeleted { get; set; }
        public int? UserId { get; set; }
        public string? Path { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}