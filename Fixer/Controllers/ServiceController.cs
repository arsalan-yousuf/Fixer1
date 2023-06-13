using Microsoft.AspNetCore.Mvc;

namespace Fixer.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
