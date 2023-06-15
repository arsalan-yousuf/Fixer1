using Fixer.Models;
using Fixer.Models.VMs;
using Fixer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ServiceCategory servCat)
        {
            MemoryStream stream = new MemoryStream();   //used to convert file to byte array
            servCat.ServiceCategoryPicture.CopyTo(stream);  // copies picture into mem stream
            servCat.ServiceCategoryByteImage = stream.ToArray();
            _serviceCategoryRepo.CreateServiceCategory(servCat);
            return RedirectToAction("ShowAll");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            _serviceCategoryRepo.DeleteServiceCategory(id);
            return RedirectToAction("ShowAll");
        }
        public IActionResult ShowAll()
        {
            return View(_serviceCategoryRepo.GetAllServiceCategory("asc"));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, ServiceCategory servCat)
        {
            _serviceCategoryRepo.UpdateServiceCategory(servCat);
            return RedirectToAction("ShowAll");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ShowAllAdmin()
        {
            return View(_serviceCategoryRepo.GetAllServiceCategory("asc"));
        }


    }
}
