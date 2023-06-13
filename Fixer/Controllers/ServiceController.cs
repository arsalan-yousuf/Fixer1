using Fixer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fixer.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service service)
        {
            return View();
        }
    }
}
