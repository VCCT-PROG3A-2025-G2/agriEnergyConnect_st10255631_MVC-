/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using System.Security.Claims;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////

namespace AgriEnergyConnect_st10255631_MVC.Services
{
    public interface IProductWorkflowService
    {
        Task<(bool Success, bool RedirectToLogin, string? FarmerName, FarmerDashboardViewModel ViewModel)> GetFarmerDashboardAsync(ClaimsPrincipal user);
        Task<(bool Success, bool RedirectToLogin, string? FarmerName, FarmerDashboardViewModel ViewModel)> AddProductAsync(ClaimsPrincipal user, FarmerDashboardViewModel viewModel);
        Task<(bool Success, bool RedirectToLogin, Product? Product)> GetEditProductAsync(ClaimsPrincipal user, int id);
        Task<(bool Success, bool RedirectToLogin)> EditProductAsync(ClaimsPrincipal user, int id, Product product);
        Task<(bool Success, bool RedirectToLogin, Product? Product)> GetDeleteProductAsync(ClaimsPrincipal user, int id);
        Task<(bool Success, bool RedirectToLogin)> DeleteProductAsync(ClaimsPrincipal user, int id);
    }
}
/////////////////////////////////////////END OF FILE//////////////////////////////////////////////////////////////////
