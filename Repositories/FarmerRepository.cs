/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////

using AgriEnergyConnect_st10255631_MVC.Data;
using AgriEnergyConnect_st10255631_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////


namespace AgriEnergyConnect_st10255631_MVC.Repositories
{
    // Repository for handling Farmer data access logic
    public class FarmerRepository : IFarmerRepository
    {

        private readonly ApplicationDbContext _context;

        public FarmerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves all farmers from the database, ordered by name
        public async Task<IEnumerable<Farmer>> GetAllFarmersAsync()
        {
            return await _context.Farmers
                .OrderBy(f => f.Name)
                .ToListAsync();
        }

        // Retrieves a farmer profile by the associated user ID
        public async Task<Farmer?> GetFarmerByUserIdAsync(int userId)
        {

            return await _context.Farmers
                .FirstOrDefaultAsync(f => f.UserId == userId);
        }

        // Adds a new farmer to the database
        public async Task AddFarmerAsync(Farmer farmer)
        {
            _context.Farmers.Add(farmer);
            await _context.SaveChangesAsync();
        }
    }
}
////////////////////////////////////////////////////////////END OF FILE////////////////////////////////////////////////////////////