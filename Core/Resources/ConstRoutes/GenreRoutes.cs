namespace Core.Resources.ConstRoutes
{
    public static class GenreRoutes
    {
        private const string BASE = "api/genre/";

        public const string Create = BASE + "create";
        public const string Update = BASE + "update";
        public const string Recovery = BASE + "recovery/{id}";
        public const string Delete = BASE + "delete/{id}";
        public const string DeleteWithoutRecovery = BASE + "deleteWithoutRecovery/{id}";

        public const string GetAll = BASE + "all";
        public const string GetAllActive = BASE + "allActive";
        public const string GetAllDeleted = BASE + "allDeleted";
        public const string GetById = BASE + "get/{id}";
    }
}