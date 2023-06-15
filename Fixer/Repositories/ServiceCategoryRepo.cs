using Fixer.Areas.Identity.Data;
using Fixer.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Fixer.Repositories
{
    public class ServiceCategoryRepo : I_ServiceCategoryRepo
    {
        private readonly FixerContext _context;
        public ServiceCategoryRepo(FixerContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public int CreateServiceCategory(ServiceCategory servCat)
        {
            _context.Service_Category.Add(servCat);
            return _context.SaveChanges();
        }
        [Authorize(Roles = "Admin")]
        public int DeleteServiceCategory(int servCatId)
        {
            _context.Service_Category.Remove(_context.Service_Category.Where(a => a.ServiceCategoryID == servCatId).SingleOrDefault());
            return _context.SaveChanges();
        }

        public List<ServiceCategory> GetAllServiceCategory(string sortOrder)
        {
            if (sortOrder == "asc")
            {
                sortOrder = "desc";
                return _context.Service_Category.OrderBy(a => a.ServiceCategoryName).ToList();

            }
            else if (sortOrder == "desc")
            {
                sortOrder = "asc";
                return _context.Service_Category.OrderByDescending(a => a.ServiceCategoryName).ToList();

            }
            return _context.Service_Category.ToList();
        }
        [Authorize(Roles = "Admin")]
        public int UpdateServiceCategory(ServiceCategory servCat)
        {
            _context.Service_Category.Update(servCat);
            return _context.SaveChanges();
        }
        public ServiceCategory GetServiceCategory(int servCatId)
        {
            return _context.Service_Category.Where(a => a.ServiceCategoryID == servCatId).SingleOrDefault();
        }
    }
}
