namespace Core.DTOs.Publisher
{
    public class PublisherCreateDTO
    {
        /// <example>Sony Universal Music</example>
        public string Name { get; set; }

        /// <example>INSERT BASE64</example>
        public string Image { get; set; }

        /// <example>The biggest music company in the world</example>
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
