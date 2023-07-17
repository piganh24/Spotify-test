using Core.DTOs;
using Core.DTOs.Account;
using Core.DTOs.Identity;
using Core.Entities.Identity;

namespace Core.Interfaces
{
    public interface IAccountUserServices
    {
        Task SignUpAsync(SignUpItemDTO userSignUpDTO);
        Task<SignInResponseDTO> SignInAsync(string userEmail, string password);
        Task SignOutAsync();

        Task UpdateUserAsync(UserUpdateDTO userUpdateDTO);
        Task<bool> ConfirmUserEmailAsync(string userEmail, string userUniqueVerificationCode);
        Task ChangePasswordAsync(string userEmail, string newPassword,string confirmPassword);
        Task DeleteUserAsync(string userEmail, string userPassword);
        Task DeleteUserWithoutRecoveryAsync(string userEmail, string userPassword);
        Task RecoveryUser(string userEmail, string userPassword);

        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<IEnumerable<UserEntity>> GetAllDeletedUsersAsync();
        Task<IEnumerable<UserEntity>> GetAllActiveUsersAsync();
        Task<UserEntity> GetUserByEmailAsync(string userEmail);
        Task<UserEntity> GetUserByUsernameAsync(string userName);
        Task<UserEntity> GetUserByIdAsync(int userId);
    }
}