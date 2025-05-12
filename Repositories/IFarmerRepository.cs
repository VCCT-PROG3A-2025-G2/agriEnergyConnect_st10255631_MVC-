/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////

using AgriEnergyConnect_st10255631_MVC.Models;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////


namespace AgriEnergyConnect_st10255631_MVC.Repositories
{

    public interface IFarmerRepository
    {
        // Retrieves a farmer profile by the user ID
        Task<Farmer?> GetFarmerByUserIdAsync(int userId);

        // Adds a new farmer to the database
        Task AddFarmerAsync(Farmer farmer);

        // Retrieves all farmers from the database
        Task<IEnumerable<Farmer>> GetAllFarmersAsync();


    }
}
////////////////////////////////////////////////////////////END OF FILE////////////////////////////////////////////////////////////