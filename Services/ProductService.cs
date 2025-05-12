/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using AgriEnergyConnect_st10255631_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////

namespace AgriEnergyConnect_st10255631_MVC.Services
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Adds a new product for a specific farmer
        public async Task AddProductForFarmerAsync(Product product, int farmerId)
        {
            product.FarmerId = farmerId;
            product.AddedDate = DateTime.UtcNow;
            await _productRepository.AddProductAsync(product);
        }

        // Retrieves all products for a specific farmer
        public async Task<IEnumerable<Product>> GetProductsForFarmerAsync(int farmerId)
        {
            return await _productRepository.GetProductsByFarmerIdAsync(farmerId);
        }

        // Retrieves a product by its ID
        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }

        // Retrieves all products for employees for filter
        public async Task<IEnumerable<Product>> GetAllProductsForEmployeeAsync(
            string? productType, DateTime? startDate, DateTime? endDate)
        {
            var allProducts = await _productRepository.GetAllProductsAsync();

            // Filter by product type if provided
            if (!string.IsNullOrWhiteSpace(productType))
            {
                allProducts = allProducts.Where(p =>
                    p.Category.Equals(productType, StringComparison.OrdinalIgnoreCase));
            }
            // Filter by start date 
            if (startDate.HasValue)
            {
                allProducts = allProducts.Where(p => p.ProductionDate >= startDate.Value);
            }
            // Filter by end date
            if (endDate.HasValue)
            {
                allProducts = allProducts.Where(p => p.ProductionDate <= endDate.Value);
            }
            return allProducts;
        }

        // Updates an existing product
        public async Task UpdateProductAsync(Product product)
        {

            await _productRepository.UpdateProductAsync(product);
        }
        // Retrieves all products
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }
        // Deletes a product
        public async Task DeleteProductAsync(int productId)
        {
            await _productRepository.DeleteProductAsync(productId);
        }


    }
}
////////////////////////////////////////////////////////////END OF FILE////////////////////////////////////////////////////////////

