/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////

namespace AgriEnergyConnect_st10255631_MVC.Services
{
    public interface IEmployeeService
    {
        // Gets the dashboard view model for an employee filtered by the provided model
        Task<EmployeeDashboardViewModel> GetDashboardViewModelAsync(EmployeeDashboardViewModel filterModel);
        // Adds a new farmer using the provided model, returns success status and error message if any
        Task<(bool Success, string? ErrorMessage)> AddFarmerAsync(AddFarmerViewModel model);
    }
}
/////////////////////////////////////////END OF FILE//////////////////////////////////////////////////////////////////
