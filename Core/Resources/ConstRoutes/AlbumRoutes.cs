namespace Core.Resources.ConstRoutes
{
    public static class AlbumRoutes
    {
        private const string BASE = "api/album/";

        public const string Create = BASE + "create";
        public const string Update = BASE + "update";
        public const string Recovery = BASE + "recovery/{id}";
        public const string Delete = BASE + "delete/{id}";
        public const string DeleteWithoutRecovery = BASE + "deleteWithoutRecovery/{id}";

        public const string GetAll = BASE + "all";
        public const string GetAllPublic = BASE + "allPublic";
        public const string GetById = BASE + "get/{id}";
        public const string AllByGenreId = BASE + "allByGenre/{genreId}";
        public const string AllByPerformerId = BASE + "allByPeformer/{performerId}";
        public const string AllMyOwnAlbums = BASE + "my";
    }
}