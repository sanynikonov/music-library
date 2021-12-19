using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public interface IAuthService
    {
        Task<SignInResult> LoginAsync(LoginModel model);
        Task<SignInResult> TryLoginAsync(LoginModel model);
        Task<IdentityResult> RegisterAsync(RegisterModel model);
        string GetUserId(ClaimsPrincipal principal);
        Task LogoutAsync();
    }
}
