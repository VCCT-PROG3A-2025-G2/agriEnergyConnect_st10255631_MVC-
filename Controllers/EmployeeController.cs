/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using AgriEnergyConnect_st10255631_MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////


namespace AgriEnergyConnect_st10255631_MVC.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public async Task<IActionResult> Dashboard(EmployeeDashboardViewModel filterModel)
        {
            var viewModel = await _employeeService.GetDashboardViewModelAsync(filterModel);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddFarmer()
        {
            return View(new AddFarmerViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFarmer(AddFarmerViewModel model)
        {
            var result = await _employeeService.AddFarmerAsync(model);
            if (result.Success)
            {
                TempData["SuccessMessage"] = $"Farmer '{model.FarmerName}' created successfully.";
                return RedirectToAction(nameof(Dashboard));
            }
            else
            {
                ModelState.AddModelError(string.Empty, result.ErrorMessage ?? "Failed to create farmer account.");
                return View("AddFarmer", model);
            }
        }
    }
}
////////////////////////////////////////////////////////////END OF FILE////////////////////////////////////////////////////////////