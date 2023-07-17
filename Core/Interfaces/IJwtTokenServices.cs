﻿using Core.DTOs.Account.Google;
using Core.Entities.Identity;
using Google.Apis.Auth;

namespace Core.Interfaces
{
    public interface IJwtTokenServices
    {
        Task<string> CreateTokenAsync(UserEntity user);
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalLoginRequest request);
    }
}