namespace Core.Resources.ConstRoutes
{
    public static class TrackRoutes
    {
        private const string BASE = "api/track/";

        public const string Create = BASE + "create";
        public const string Update = BASE + "update";
        public const string Recovery = BASE + "recovery/{id}";
        public const string Delete = BASE + "delete/{id}";
        public const string DeleteWithoutRecovery = BASE + "deleteWitoutRecovery/{id}";

        public const string GetAll = BASE + "all";
        public const string GetAllActive = BASE + "allActive";
        public const string GetAllDeleted = BASE + "allDeleted";
        public const string GetAllPublic = BASE + "allpublic";
        public const string GetAllExplicit = BASE + "allExplicit";

        public const string GetById = BASE + "get/{id}";
        public const string GetAllByGenreId = BASE + "allByGenre/{genreId}";
        public const string GetAllByPerformertId = BASE + "allByPerformer/{performerId}";
        public const string GetAllMyOwnTracks = BASE + "my";
    }
}