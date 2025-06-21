/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using System.Security.Claims;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////

namespace AgriEnergyConnect_st10255631_MVC.Services
{
    // Gets the farmer's dashboard view model based on the logged-in user
    public interface IProductWorkflowService
    {

        // Gets the farmer's dashboard view model based on the logged-in user
        Task<(bool Success, bool RedirectToLogin, string? FarmerName, FarmerDashboardViewModel ViewModel)> GetFarmerDashboardAsync(ClaimsPrincipal user);
        // Adds a new product for the farmer and returns the updated dashboard view model
        Task<(bool Success, bool RedirectToLogin, string? FarmerName, FarmerDashboardViewModel ViewModel)> AddProductAsync(ClaimsPrincipal user, FarmerDashboardViewModel viewModel);
        // Gets the product to edit for the farmer by product ID
        Task<(bool Success, bool RedirectToLogin, Product? Product)> GetEditProductAsync(ClaimsPrincipal user, int id);
        // Edits the product for the farmer by product ID
        Task<(bool Success, bool RedirectToLogin)> EditProductAsync(ClaimsPrincipal user, int id, Product product);
        // Gets the product to delete for the farmer by product ID
        Task<(bool Success, bool RedirectToLogin, Product? Product)> GetDeleteProductAsync(ClaimsPrincipal user, int id);
        // Deletes the product for the farmer by product ID
        Task<(bool Success, bool RedirectToLogin)> DeleteProductAsync(ClaimsPrincipal user, int id);
    }
}
/////////////////////////////////////////END OF FILE//////////////////////////////////////////////////////////////////
