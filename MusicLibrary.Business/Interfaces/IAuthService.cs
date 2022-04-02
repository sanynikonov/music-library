using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Interfaces;

public interface IAuthService
{
    Task<SignInResult> LoginAsync(LoginModel model);
    Task<SignInResult> TryLoginAsync(LoginModel model);
    Task<IdentityResult> RegisterAsync(RegisterModel model);
    string GetUserId(ClaimsPrincipal principal);
    Task LogoutAsync();
}