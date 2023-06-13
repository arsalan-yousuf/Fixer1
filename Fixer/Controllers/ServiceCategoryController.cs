using Fixer.Models;
using Fixer.Models.VMs;
using Fixer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Fixer.Controllers
{
    public class ServiceCategoryController : Controller
    {
        private readonly I_ServiceCategoryRepo _serviceCategoryRepo;
        private readonly I_ServiceRepo _serviceRepo;

        public ServiceCategoryController(I_ServiceCategoryRepo serviceCategoryRepo, I_ServiceRepo serviceRepo)
        {
            _serviceCategoryRepo = serviceCategoryRepo;
            _serviceRepo = serviceRepo;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServiceCategory servCat)
        {
            _serviceCategoryRepo.CreateServiceCategory(servCat);
            return View();
        }
        public IActionResult Remove(int id)
        {
            _serviceCategoryRepo.DeleteServiceCategory(id);
            return View();
        }
        public IActionResult ShowAll()
        {
            return View(_serviceCategoryRepo.GetAllServiceCategory("asc"));
        }


    }
}
