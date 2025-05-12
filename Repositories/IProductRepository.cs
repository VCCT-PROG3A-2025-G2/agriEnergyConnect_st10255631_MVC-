/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////


namespace AgriEnergyConnect_st10255631_MVC.Repositories
{
    public interface IProductRepository
    {
        // Retrieves a product by its unique ID
        Task<Product?> GetProductByIdAsync(int productId);
        // Retrieves all products belonging to a specific farmer
        Task<IEnumerable<Product>> GetProductsByFarmerIdAsync(int farmerId);
        // Adds a new product to the database
        Task AddProductAsync(Product product);
        // Updates an existing product in the database
        Task UpdateProductAsync(Product product);
        // Deletes a product from the database by its ID
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync(); // For employee view


    }
}
/////////////////////////////////////////////////////////END OF FILE/////////////////////////////////////////////////////////