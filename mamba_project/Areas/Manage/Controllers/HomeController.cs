using Microsoft.AspNetCore.Mvc;

namespace mamba_project.Areas.Areas.Controllers
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
