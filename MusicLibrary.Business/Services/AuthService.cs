using Microsoft.AspNetCore.Identity;
using MusicLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
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
            var user = await _unit.UserManager.FindByNameAsync(model.Login) ?? await _unit.UserManager.FindByEmailAsync(model.Login);
            return await _unit.SignInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);
        }


        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            var user = await _unit.UserManager.FindByNameAsync(model.Login) ?? await _unit.UserManager.FindByEmailAsync(model.Login);
            return await _unit.SignInManager.PasswordSignInAsync(user.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
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
                Email = model.Email,
            };

            return await _unit.SignInManager.UserManager.CreateAsync(user, model.Password);
        }
    }
}
