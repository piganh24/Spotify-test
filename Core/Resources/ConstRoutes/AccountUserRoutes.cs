namespace Core.Resources.ConstRoutes
{
    public static class AccountUserRoutes
    {
        private const string BASE = "api/user/";

        public const string GoogleAuth = BASE + "google";
        public const string SignUp = BASE + "signUp";
        public const string SignIn = BASE + "signIn";
        public const string SignOut = BASE + "signOut";

        public const string Update = BASE + "update";
        public const string ConfirmEmail = BASE + "confirm/{userEmail}/{userUniqueVerificationCode}";
        public const string ChangePassword = BASE + "changePassword/{userEmail}/{newPassword}/{confirmPassword}";
        public const string Recovery = BASE + "recovery";
        public const string Delete = BASE + "delete";
        public const string DeleteWithoutRecovery = BASE + "deleteWithoutRecovery";
        public const string GetAllUsers = BASE + "all";
        public const string GetAllActiveUsers = BASE + "allActive";
        public const string GetAllDeletedUsers = BASE + "allDeleted";

        public const string GetUserByEmail = BASE + "getByEmail/{userEmail}";
        public const string GetUserByUsername = BASE + "getByUserName/{username}";
        public const string GetUserById = BASE + "getById/{userId}";
    }
}