using Microsoft.AspNetCore.Mvc;

namespace KingmanAzFrcTeam60
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
