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
        private readonly IFarmerService _farmerService;
        private readonly IProductService _productService;
        private readonly ILogger<ProductWorkflowService> _logger;

        public ProductWorkflowService(
            IFarmerService farmerService,
            IProductService productService,
            ILogger<ProductWorkflowService> logger)
        {
            _farmerService = farmerService;
            _productService = productService;
            _logger = logger;
        }

        private async Task<Farmer?> GetCurrentFarmerAsync(ClaimsPrincipal user)
        {
            var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                return null;
            return await _farmerService.GetFarmerByUserIdAsync(userId);
        }

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

        public async Task<(bool Success, bool RedirectToLogin, Product? Product)> GetEditProductAsync(ClaimsPrincipal user, int id)
        {
            var farmer = await GetCurrentFarmerAsync(user);
            if (farmer == null) return (false, true, null);

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null || product.FarmerId != farmer.Id)
                return (false, false, null);

            return (true, false, product);
        }

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

        public async Task<(bool Success, bool RedirectToLogin, Product? Product)> GetDeleteProductAsync(ClaimsPrincipal user, int id)
        {
            var farmer = await GetCurrentFarmerAsync(user);
            if (farmer == null) return (false, true, null);

            var product = await _productService.GetProductByIdAsync(id);
            if (product == null || product.FarmerId != farmer.Id)
                return (false, false, null);

            return (true, false, product);
        }

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
