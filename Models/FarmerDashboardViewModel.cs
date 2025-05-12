/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using agri_enegry.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////
///
namespace AgriEnergyConnect_st10255631_MVC.Models
{
   // ViewModel for the Farmer Dashboard page
    // Holds data for displaying and adding products
    public class FarmerDashboardViewModel
    {

        public Product NewProduct { get; set; } = new Product();


        public IEnumerable<Product> MyProducts { get; set; } = new List<Product>();
    }
}
////////////////////////////////////////////////////////////END OF FILE////////////////////////////////////////////////////////////