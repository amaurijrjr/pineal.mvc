using Microsoft.AspNetCore.Mvc;

namespace PinealWebMvc.Controllers
{
    public class ImagemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
