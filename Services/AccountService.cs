/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using AgriEnergyConnect_st10255631_MVC.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////

namespace AgriEnergyConnect_st10255631_MVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        // Constructor to inject the user repository
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Validates the user's credentials
        public async Task<User?> ValidateCredentialsAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null) return null;
            if (user.PasswordHash == password) return user;
            return null;
        }

        // Signs in the user and creates authentication cookies
        public async Task<(bool Success, string? ErrorMessage, string? Role)> SignInAsync(HttpContext httpContext, LoginViewModel model)
        {
            var user = await ValidateCredentialsAsync(model.Username, model.Password);
            if (user == null)
                return (false, "Invalid login attempt.", null);

            // Create claims for the user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // Create identity and sign in
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties());

            return (true, null, user.Role);
        }

        // Signs out the current user
        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
/////////////////////////////////////////END OF FILE//////////////////////////////////////////////////////////////////
