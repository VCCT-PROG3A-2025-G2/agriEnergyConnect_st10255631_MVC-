/////////////////////////////////////////START OF IMPORTS//////////////////////////////////////////////////////////////////
using System.ComponentModel.DataAnnotations;
/////////////////////////////////////////END OF IMPORTS//////////////////////////////////////////////////////////////////

namespace AgriEnergyConnect_st10255631_MVC.Models
{
    //allows for logging in + required fields
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
////////////////////////////////////////////////////////////END OF FILE////////////////////////////////////////////////////////////
