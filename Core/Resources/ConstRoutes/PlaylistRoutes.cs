namespace Core.Resources.ConstRoutes
{
    public static class PlaylistRoutes
    {
        private const string BASE = "api/playlist/";

        public const string Create = BASE + "create";
        public const string Update = BASE + "update";
        public const string Recovery = BASE + "recovery/{id}";
        public const string Delete = BASE + "delete/{id}";
        public const string DeleteWithoutRecovery = BASE + "deleteWithoutRecovery/{id}";

        public const string GetAll = BASE + "all";
        public const string GetById = BASE + "get/{id}";
        public const string GetAllByGenreId = BASE + "allByGenre/{genreId}";
        public const string GetAllMyOwnPlaylists = BASE + "my";
    }
}