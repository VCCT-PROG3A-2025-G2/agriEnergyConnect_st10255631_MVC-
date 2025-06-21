/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////


namespace AgriEnergyConnect_st10255631_MVC.Services
{
    public class ProductWorkflowService : IProductWorkflowService
    {
        // Dependencies for farmer, product services, and logging
        private readonly IFarmerService _farmerService;
        private readonly IProductService _productService;
        private readonly ILogger<ProductWorkflowService> _logger;

        // Constructor to inject dependencies
        public ProductWorkflowService(
            IFarmerService farmerService,
            IProductService productService,
            ILogger<ProductWorkflowService> logger)
        {
            _farmerService = farmerService;
            _productService = productService;
            _logger = logger;
        }

        // Helper method to get the current farmer based on the logged-in user
        private async Task<Farmer?> GetCurrentFarmerAsync(ClaimsPrincipal user)
        {
            var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                return null;
            return await _farmerService.GetFarmerByUserIdAsync(userId);
        }

        // Gets the dashboard view model for the current farmer
        public async Task<(bool Success, bool RedirectToLogin, string? FarmerName, FarmerDashboardViewModel ViewModel)> GetFarmerDashboardAsync(ClaimsPrincipal user)
        {
            var farmer = await GetCurrentFarmerAsync(user);
            if (farmer == null)
                return (false, true, null, null);

            var products = await _productService.GetProductsForFarmerAsync(farmer.Id);
            var viewModel = new FarmerDashboardViewModel
            {
                NewProduct = new Product { ProductionDate = DateTime.Today },
                MyProducts = products
            };
            return (true, false, farmer.Name, viewModel);
        }

        // Adds a new product for the current farmer and returns the updated dashboard
        public async Task<(bool Success, bool RedirectToLogin, string? FarmerName, FarmerDashboardViewModel ViewModel)> AddProductAsync(ClaimsPrincipal user, FarmerDashboardViewModel viewModel)
        {
            var farmer = await GetCurrentFarmerAsync(user);
            if (farmer == null)
                return (false, true, null, null);

            var productToAdd = viewModel.NewProduct;

 
            try
            {
                await _productService.AddProductForFarmerAsync(productToAdd, farmer.Id);
                var products = await _productService.GetProductsForFarmerAsync(farmer.Id);
                var newViewModel = new FarmerDashboardViewModel
                {
                    NewProduct = new Product { ProductionDate = DateTime.Today },
                    MyProducts = products
                };
                return (true, false, farmer.Name, newViewModel);
            }
            catch (Exception ex)
            {
                // Log the error if adding the product fails
                _logger.LogError(ex, "Error adding product for farmer {FarmerId}", farmer.Id);
                var products = await _productService.GetProductsForFarmerAsync(farmer.Id);
                var newViewModel = new FarmerDashboardViewModel
                {
                    NewProduct = productToAdd ?? new Product { ProductionDate = DateTime.Today },
                    MyProducts = products
                };
                return (false, false, farmer.Name, newViewModel);
            }
        }

        // Gets the product to edit for the current farmer by product ID
        public async Task<(bool Success, bool RedirectToLogin, Product? Product)> GetEditProductAsync(ClaimsPrincipal user, int id)
        {
            var farmer = await GetCurrentFarmerAsync(user);
            if (farmer == null) return (false, true, null);

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null || product.FarmerId != farmer.Id)
                return (false, false, null);

            return (true, false, product);
        }

        // Edits the product for the current farmer by product ID
        public async Task<(bool Success, bool RedirectToLogin)> EditProductAsync(ClaimsPrincipal user, int id, Product product)
        {
            var farmer = await GetCurrentFarmerAsync(user);
            if (farmer == null) return (false, true);

            if (id != product.Id)
                return (false, false);

            var originalProduct = await _productService.GetProductByIdAsync(id);
            if (originalProduct == null || originalProduct.FarmerId != farmer.Id)
                return (false, false);

            product.FarmerId = originalProduct.FarmerId;
            product.AddedDate = originalProduct.AddedDate;
            product.Farmer = null;

            try
            {
                await _productService.UpdateProductAsync(product);
                return (true, false);
            }
            catch
            {
                return (false, false);
            }
        }

        // Gets the product to delete for the current farmer by product ID
        public async Task<(bool Success, bool RedirectToLogin, Product? Product)> GetDeleteProductAsync(ClaimsPrincipal user, int id)
        {
            var farmer = await GetCurrentFarmerAsync(user);
            if (farmer == null) return (false, true, null);

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null || product.FarmerId != farmer.Id)
                return (false, false, null);

            return (true, false, product);
        }

        // Deletes the product for the current farmer by product ID
        public async Task<(bool Success, bool RedirectToLogin)> DeleteProductAsync(ClaimsPrincipal user, int id)
        {
            var farmer = await GetCurrentFarmerAsync(user);
            if (farmer == null) return (false, true);

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null || product.FarmerId != farmer.Id)
                return (false, false);

            await _productService.DeleteProductAsync(id);
            return (true, false);
        }
    }
}
/////////////////////////////////////////END OF FILE//////////////////////////////////////////////////////////////////
