/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using AgriEnergyConnect_st10255631_MVC.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////


namespace AgriEnergyConnect_st10255631_MVC.Services
{
    // Implementation of employee-related services
    public class EmployeeService : IEmployeeService
    {
        private readonly IFarmerService _farmerService;
        private readonly IProductService _productService;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(
            IFarmerService farmerService,
            IProductService productService,
            ILogger<EmployeeService> logger)
        {
            _farmerService = farmerService;
            _productService = productService;
            _logger = logger;
        }

        // Gets the dashboard view model for employees, with optional filters
        public async Task<EmployeeDashboardViewModel> GetDashboardViewModelAsync(EmployeeDashboardViewModel filterModel)
        {
            // Get all farmers and create a list for dropdown selection
            var farmers = await _farmerService.GetAllFarmersAsync();
            var farmerListItems = farmers
                .Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Name })
                .ToList();

            // Add a default option for all farmers
            farmerListItems.Insert(0, new SelectListItem { Value = "", Text = "--- All Farmers ---" });

            // Get all products
            var products = await _productService.GetAllProductsAsync();

            // Filter products by selected farmer if specified
            if (filterModel.SelectedFarmerId.HasValue)
                products = products.Where(p => p.FarmerId == filterModel.SelectedFarmerId.Value);

            // Filter products by product type if specified
            if (!string.IsNullOrWhiteSpace(filterModel.FilterProductType))
                products = products.Where(p => p.Category.Equals(filterModel.FilterProductType, StringComparison.OrdinalIgnoreCase));

            // Filter products by start date if specified
            if (filterModel.FilterStartDate.HasValue)
                products = products.Where(p => p.ProductionDate.Date >= filterModel.FilterStartDate.Value.Date);

            // Filter products by end date if specified
            if (filterModel.FilterEndDate.HasValue)
                products = products.Where(p => p.ProductionDate.Date <= filterModel.FilterEndDate.Value.Date);

            // Return the dashboard view model with filtered products and available farmers
            return new EmployeeDashboardViewModel
            {
                AvailableFarmers = farmerListItems,
                SelectedFarmerId = filterModel.SelectedFarmerId,
                FilterProductType = filterModel.FilterProductType,
                FilterStartDate = filterModel.FilterStartDate,
                FilterEndDate = filterModel.FilterEndDate,
                Products = products.ToList()
            };
        }

        // Adds a new farmer using the provided model
        public async Task<(bool Success, string? ErrorMessage)> AddFarmerAsync(AddFarmerViewModel model)
        {
            return await _farmerService.CreateFarmerWithUserAsync(model);
        }
    }
}
/////////////////////////////////////////END OF FILE//////////////////////////////////////////////////////////////////
