using Fixer.Models;
using Fixer.Models.VMs;
using Fixer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Data;
using System.Numerics;

namespace Fixer.Controllers
{
    public class ServiceController : Controller
    {
        private readonly I_ServiceRepo _serviceRepo;
        private readonly I_ServiceCategoryRepo _serviceCategoryRepo;

        public ServiceController(I_ServiceRepo serviceRepo, I_ServiceCategoryRepo serviceCategoryRepo)
        {
            _serviceRepo = serviceRepo;
            _serviceCategoryRepo = serviceCategoryRepo;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.serviceCategories = _serviceCategoryRepo.GetAllServiceCategory("asc");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Service service)
        {
            MemoryStream stream = new MemoryStream();   //used to convert file to byte array
            service.ServicePicture.CopyTo(stream);  // copies picture into mem stream
            service.ServiceByteImage = stream.ToArray();  // converts mem stream to byte array
            _serviceRepo.CreateService(service);
            return RedirectToAction("ShowAll");
        }
        public IActionResult ShowAll(int servCatID)
        {
            if (servCatID != 0)
            {
                List<ServiceVM> result = _serviceRepo.GetServiceByCategory(servCatID);
                ViewBag.ServiceCat = _serviceCategoryRepo.GetServiceCategory(servCatID);
                return View("ServiceByCategory", result);
            }
            else
            {
                List<Service> result = _serviceRepo.GetAllService("asc");
                return View(result);
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            _serviceRepo.DeleteService(id);
            return RedirectToAction("ShowAll");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, Service service)
        {
            _serviceRepo.UpdateService(service);
            return RedirectToAction("ShowAll");
        }
        public IActionResult ServiceByCategory(int servCatId)
        {
            return View();
        }
    }
}
