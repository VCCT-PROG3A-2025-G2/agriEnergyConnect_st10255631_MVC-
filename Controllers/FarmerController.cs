using Microsoft.AspNetCore.Mvc;

namespace agri_enegry.Controllers
{
    public class FarmerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
