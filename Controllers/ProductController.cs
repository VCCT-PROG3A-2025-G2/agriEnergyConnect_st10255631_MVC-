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
    [Authorize(Roles = "Farmer")]
    public class ProductController : Controller
    {
        private readonly IProductWorkflowService _productWorkflowService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(
            IProductWorkflowService productWorkflowService,
            ILogger<ProductController> logger)
        {
            _productWorkflowService = productWorkflowService;
            _logger = logger;
        }

        public async Task<IActionResult> FarmerProducts()
        {
            var result = await _productWorkflowService.GetFarmerDashboardAsync(User);
            if (!result.Success)
                return RedirectToAction("Login", "Account");

            ViewBag.FarmerName = result.FarmerName;
            return View("~/Views/Home/FarmerDashboard.cshtml", result.ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(FarmerDashboardViewModel viewModel)
        {
            var result = await _productWorkflowService.AddProductAsync(User, viewModel);
            if (result.RedirectToLogin)
                return RedirectToAction("Login", "Account");

            if (result.Success)
            {
                TempData["SuccessMessage"] = "Product added successfully!";
                return RedirectToAction(nameof(FarmerProducts));
            }

            ViewBag.FarmerName = result.FarmerName;
            return View("~/Views/Home/FarmerDashboard.cshtml", result.ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _productWorkflowService.GetEditProductAsync(User, id);
            if (result.RedirectToLogin)
                return RedirectToAction("Login", "Account");
            if (!result.Success)
                return NotFound();

            return View("EditProduct", result.Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            var result = await _productWorkflowService.EditProductAsync(User, id, product);
            if (result.RedirectToLogin)
                return RedirectToAction("Login", "Account");
            if (!result.Success)
                return View("EditProduct", product);

            TempData["SuccessMessage"] = "Product updated successfully!";
            return RedirectToAction(nameof(FarmerProducts));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productWorkflowService.GetDeleteProductAsync(User, id);
            if (result.RedirectToLogin)
                return RedirectToAction("Login", "Account");
            if (!result.Success)
                return NotFound();

            return View("DeleteProduct", result.Product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _productWorkflowService.DeleteProductAsync(User, id);
            if (result.RedirectToLogin)
                return RedirectToAction("Login", "Account");

            TempData["SuccessMessage"] = "Product deleted successfully!";
            return RedirectToAction(nameof(FarmerProducts));
        }
    }
}
/////////////////////////////////////////END OF FILE//////////////////////////////////////////////////////////////////
