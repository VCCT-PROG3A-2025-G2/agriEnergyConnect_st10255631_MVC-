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

        public async Task<EmployeeDashboardViewModel> GetDashboardViewModelAsync(EmployeeDashboardViewModel filterModel)
        {
            var farmers = await _farmerService.GetAllFarmersAsync();
            var farmerListItems = farmers
                .Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.Name })
                .ToList();

            farmerListItems.Insert(0, new SelectListItem { Value = "", Text = "--- All Farmers ---" });

            var products = await _productService.GetAllProductsAsync();

            if (filterModel.SelectedFarmerId.HasValue)
                products = products.Where(p => p.FarmerId == filterModel.SelectedFarmerId.Value);

            if (!string.IsNullOrWhiteSpace(filterModel.FilterProductType))
                products = products.Where(p => p.Category.Equals(filterModel.FilterProductType, StringComparison.OrdinalIgnoreCase));

            if (filterModel.FilterStartDate.HasValue)
                products = products.Where(p => p.ProductionDate.Date >= filterModel.FilterStartDate.Value.Date);

            if (filterModel.FilterEndDate.HasValue)
                products = products.Where(p => p.ProductionDate.Date <= filterModel.FilterEndDate.Value.Date);

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

        public async Task<(bool Success, string? ErrorMessage)> AddFarmerAsync(AddFarmerViewModel model)
        {
            return await _farmerService.CreateFarmerWithUserAsync(model);
        }
    }
}
/////////////////////////////////////////END OF FILE//////////////////////////////////////////////////////////////////
