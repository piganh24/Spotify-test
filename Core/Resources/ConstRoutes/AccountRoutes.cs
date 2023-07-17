namespace Core.Resources.ConstRoutes
{
    public static class AccountRoutes
    {
        private const string BASE = "api/account/";

        public const string GoogleAuth = BASE + "GoogleExternalLogin";
        public const string SignUp = BASE + "signUp";
        public const string SignIn = BASE + "signIn";
        public const string SignOut = BASE + "signOut";

        public const string UpdateUser = BASE + "updateUser";
        public const string RestoreUser = BASE + "restoreUser";
        public const string DeleteUser = BASE + "deleteUser";
        public const string DeleteUserWithoutRecovery = BASE + "deleteUserWithoutRecovery";
        public const string ConfirUserEmail = BASE + "confirmEmail";

        public const string GetAllUsers = BASE + "allUsers";
        public const string GetAllActiveUsers = BASE + "allActiveUsers";
        public const string GetAllDeletedUsers = BASE + "allDeletedUsers";

        public const string GetUserByEmail = BASE + "getUserByEmail/{userEmail}";
        public const string GetUserByUsername = BASE + "getUserByUserName/{username}";
        public const string GetUserById = BASE + "getUserById/{userId}";
    }
}