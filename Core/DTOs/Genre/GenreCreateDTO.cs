namespace Core.DTOs.Genre
{
    public class GenreCreateDTO
    {
        /// <example>Rock</example>
        public string Name { get; set; }

        /// <example>Rock for the loudest concerts</example>
        public string Description { get; set; }

        /// <example>INSERT BASE64</example>
        public string Image { get; set; }

        public bool? IsDeleted { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
