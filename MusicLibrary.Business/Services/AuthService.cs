using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MusicLibrary.Data;

namespace MusicLibrary.Business;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unit;

    public AuthService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public string GetUserId(ClaimsPrincipal principal)
    {
        return _unit.SignInManager.UserManager.GetUserId(principal);
    }

    public async Task<SignInResult> TryLoginAsync(LoginModel model)
    {
        var user = await _unit.UserManager.FindByNameAsync(model.Login) ??
                   await _unit.UserManager.FindByEmailAsync(model.Login);
        return await _unit.SignInManager.CheckPasswordSignInAsync(user, model.Password, false);
    }


    public async Task<SignInResult> LoginAsync(LoginModel model)
    {
        var user = await _unit.UserManager.FindByNameAsync(model.Login) ??
                   await _unit.UserManager.FindByEmailAsync(model.Login);
        return await _unit.SignInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
    }

    public async Task LogoutAsync()
    {
        await _unit.SignInManager.SignOutAsync();
    }

    public async Task<IdentityResult> RegisterAsync(RegisterModel model)
    {
        var user = new User
        {
            UserName = model.UserName,
            Email = model.Email
        };

        return await _unit.SignInManager.UserManager.CreateAsync(user, model.Password);
    }
}