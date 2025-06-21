/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////

namespace AgriEnergyConnect_st10255631_MVC.Services
{
    public interface IAccountService
    {
        // Validates the user's credentials (username and password)
        Task<User?> ValidateCredentialsAsync(string username, string password);

        // Signs in the user and returns a tuple with success status or error message, and user role
        Task<(bool Success, string? ErrorMessage, string? Role)> SignInAsync(HttpContext httpContext, LoginViewModel model);

        Task SignOutAsync(HttpContext httpContext);
    }
}
/////////////////////////////////////////END OF FILE//////////////////////////////////////////////////////////////////
