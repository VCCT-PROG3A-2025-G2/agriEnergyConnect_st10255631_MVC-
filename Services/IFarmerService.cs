/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using AgriEnergyConnect_st10255631_MVC.Models;
using System.Threading.Tasks;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////

namespace AgriEnergyConnect_st10255631_MVC.Services
{
    public interface IFarmerService
    {
        // Retrieves a Farmer by the associated User ID asynchronously
        Task<Farmer?> GetFarmerByUserIdAsync(int userId);



        Task<IEnumerable<Farmer>> GetAllFarmersAsync();
        //Asynchronously creates a new farmer and user account, returning whether it succeeded and an error message if not.
        Task<(bool Success, string? ErrorMessage)> CreateFarmerWithUserAsync(AddFarmerViewModel model);

    }
}
////////////////////////////////////////////////////////////END OF FILE////////////////////////////////////////////////////////////