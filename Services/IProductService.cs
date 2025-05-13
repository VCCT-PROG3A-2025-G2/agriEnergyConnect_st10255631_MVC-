/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////


namespace AgriEnergyConnect_st10255631_MVC.Services
{
    public interface IProductService
    {
        // Retrieves all products for a specific farmer
        Task<IEnumerable<Product>> GetProductsForFarmerAsync(int farmerId);
        // Adds a new product for a farmer
        Task AddProductForFarmerAsync(Product product, int farmerId);
        // Retrieves a product by its ID
        Task<Product?> GetProductByIdAsync(int productId);
        // Retrieves all products for employees
        Task<IEnumerable<Product>> GetAllProductsForEmployeeAsync(
            string? productType, DateTime? startDate, DateTime? endDate);

        // Updates an existing product
        Task UpdateProductAsync(Product product);
        // Retrieves all products
        Task<IEnumerable<Product>> GetAllProductsAsync();
        // Deletes a product
        Task DeleteProductAsync(int productId);



    }
}
////////////////////////////////////////////////////////////END OF FILE////////////////////////////////////////////////////////////