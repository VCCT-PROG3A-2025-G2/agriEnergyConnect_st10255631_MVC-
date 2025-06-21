/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using AgriEnergyConnect_st10255631_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////

namespace AgriEnergyConnect_st10255631_MVC.Controllers
{
    // Controller for account-related actions
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        // Displays the login page
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // Handles login form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var result = await _accountService.SignInAsync(HttpContext, model);

            if (result.Success)
            {
                _logger.LogInformation("User {Username} logged in successfully.", model.Username);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                // Redirect based on role
                if (result.Role == "Farmer")
                    return RedirectToAction("FarmerProducts", "Product");
                else if (result.Role == "Employee")
                    return RedirectToAction("Dashboard", "Employee");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                _logger.LogWarning("Invalid login attempt for username {Username}.", model.Username);
                ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "Invalid login attempt.");
                return View(model);
            }
        }

        // Handles user logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOutAsync(HttpContext);
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }

        // Displays the access denied page
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
////////////////////////////////////////////////////////////END OF FILE////////////////////////////////////////////////////////////