namespace Core.Resources.ConstRoutes
{
    public static class PublisherRoutes
    {
        private const string BASE = "api/publisher/";

        public const string Create = BASE + "create";
        public const string Update = BASE + "update";
        public const string Recovery = BASE + "recovery/{id}";
        public const string Delete = BASE + "delete/{id}";
        public const string DeleteWithoutRecovery = BASE + "deleteWithoutRecovery/{id}";

        public const string GetAll = BASE + "all";
        public const string GetById = BASE + "get/{id}";
    }
}