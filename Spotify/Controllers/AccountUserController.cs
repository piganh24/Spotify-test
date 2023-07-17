using Core.Interfaces;
using Core.Resources.ConstRoutes;
using Core.DTOs.Identity;
using Core.DTOs.Identity.SignIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs.Account.Google;
using Core.Entities.Identity;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Core.DTOs.Account;

namespace Spotify.Controllers
{
    [ApiController]
    [Authorize]
    public class AccountUserController : ControllerBase
    {
        private readonly IAccountUserServices _accountServices;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IJwtTokenServices _jwtTokenService;

        public AccountUserController(IAccountUserServices accountServices, UserManager<UserEntity> userManager, JwtTokenServices jwtTokenServices)
        {
            _accountServices = accountServices;
            _userManager = userManager;
            _jwtTokenService = jwtTokenServices;
        }

        [AllowAnonymous]
        [HttpPost(AccountUserRoutes.SignUp)]
        public async Task<IActionResult> SignUp([FromBody] SignUpItemDTO data)
        {
            await _accountServices.SignUpAsync(data);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost(AccountUserRoutes.SignIn)]
        public async Task<IActionResult> SignIn([FromBody] SignInUserItemDTO data)
        {
            return Ok(await _accountServices.SignInAsync(data.Email, data.Password));
        }

        [HttpPost(AccountUserRoutes.SignOut)]
        public async Task<IActionResult> SignOutAccount()
        {
            await _accountServices.SignOutAsync();
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost(AccountUserRoutes.GoogleAuth)]
        public async Task<IActionResult> GoogleExternalLoginAsync([FromBody] ExternalLoginRequest request)
        {
            try
            {
                var payload = await _jwtTokenService.VerifyGoogleToken(request);
                if (payload == null)
                {
                    return BadRequest(new { error = "Щось пішло не так!" });
                }
                var info = new UserLoginInfo(request.Provider, payload.Subject, request.Provider);
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(payload.Email);
                    if (user == null)
                    {
                        string uniqueVerificationCode = Guid.NewGuid().ToString();
                        user = new UserEntity
                        {
                            Email = payload.Email,
                            UserName = payload.Email,
                            FirstName = payload.GivenName,
                            LastName = payload.FamilyName,
                            Image = payload.Picture,
                            AboutMe = payload.FamilyName,
                            UniqueVerifiacationCode = uniqueVerificationCode,
                            IsDeleted = false,
                            IsBloked = false,
                            IsVerified = false,
                        };
                        var resultCreate = await _userManager.CreateAsync(user);
                        if (!resultCreate.Succeeded)
                        {
                            return BadRequest(new { error = "Помилка створення користувача" });
                        }
                    }
                    var resultLOgin = await _userManager.AddLoginAsync(user, info);
                    if (!resultLOgin.Succeeded)
                    {
                        return BadRequest(new { error = "Створення входу через гугл" });
                    }
                }
                string token = await _jwtTokenService.CreateTokenAsync(user);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut(AccountUserRoutes.Update)]
        public async Task<IActionResult> Update([FromBody] UserUpdateDTO data)
        {
            await _accountServices.UpdateUserAsync(data);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost(AccountUserRoutes.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromRoute] string userEmail, string userUniqueVerificationCode)
        {
            return Ok(await _accountServices.ConfirmUserEmailAsync(userEmail, userUniqueVerificationCode));
        }

        [AllowAnonymous]
        [HttpPost(AccountUserRoutes.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromRoute] string userEmail,string newPassword,string confirmPassword)
        {
            await _accountServices.ChangePasswordAsync(userEmail,newPassword, confirmPassword);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost(AccountUserRoutes.Recovery)]
        public async Task<IActionResult> Recovery([FromBody] SignInUserItemDTO data)
        {
            await _accountServices.RecoveryUser(data.Email, data.Password);
            return Ok();
        }

        [HttpDelete(AccountUserRoutes.Delete)]
        public async Task<IActionResult> DeleteAsync([FromBody] SignInUserItemDTO data)
        {
            await _accountServices.DeleteUserAsync(data.Email, data.Password);
            return Ok();
        }

        [HttpDelete(AccountUserRoutes.DeleteWithoutRecovery)]
        public async Task<IActionResult> DeleteWithoutRecoveryAsync([FromBody] SignInUserItemDTO data)
        {
            await _accountServices.DeleteUserWithoutRecoveryAsync(data.Email, data.Password);
            return Ok();
        }

        [HttpGet(AccountUserRoutes.GetAllUsers)]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _accountServices.GetAllUsersAsync());
        }

        [HttpGet(AccountUserRoutes.GetAllActiveUsers)]
        public async Task<IActionResult> GetAllActiveUsers()
        {
            return Ok(await _accountServices.GetAllActiveUsersAsync());
        }

        [HttpGet(AccountUserRoutes.GetAllDeletedUsers)]
        public async Task<IActionResult> GetAllDeletedUsers()
        {
            return Ok(await _accountServices.GetAllDeletedUsersAsync());
        }

        [HttpGet(AccountUserRoutes.GetUserByEmail)]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string userEmail)
        {
            return Ok(await _accountServices.GetUserByEmailAsync(userEmail));
        }

        [HttpGet(AccountUserRoutes.GetUserByUsername)]
        public async Task<IActionResult> GetUserByUsername([FromRoute] string username)
        {
            return Ok(await _accountServices.GetUserByUsernameAsync(username));
        }

        [HttpGet(AccountUserRoutes.GetUserById)]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            return Ok(await _accountServices.GetUserByIdAsync(userId));
        }
    }
}