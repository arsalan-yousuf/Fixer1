using Fixer.Areas.Identity.Data;
using Fixer.Models;
using Fixer.Models.VMs;

namespace Fixer.Repositories
{
    public class ServiceRepo : I_ServiceRepo
    {
        private readonly FixerContext _context;
        public ServiceRepo(FixerContext context)
        {
            _context = context;
        }
        public int CreateService(Service service)
        {
            _context.Service.Add(service);
            return _context.SaveChanges();
        }

        public int DeleteService(int serviceId)
        {
            _context.Service.Remove(_context.Service.Where(a => a.ServiceID == serviceId).SingleOrDefault());
            return _context.SaveChanges();
        }

        public List<Service> GetAllService(string sortOrder)
        {
            if (sortOrder == "asc")
            {
                sortOrder = "desc";
                return _context.Service.OrderBy(a => a.ServiceName).ToList();

            }
            else if (sortOrder == "desc")
            {
                sortOrder = "asc";
                return _context.Service.OrderByDescending(a => a.ServiceName).ToList();

            }
            return _context.Service.ToList();
        }

        public List<ServiceVM> GetServiceByCategory(int CategoryId)
        {
            List<ServiceVM> result = new List<ServiceVM>();

            if (CategoryId != 0)
            {
                //inner join using LINQ
                result = (from c in _context.Service
                          join k in _context.Service_Category on c.ServiceCategoryID equals k.ServiceCategoryID
                          where k.ServiceCategoryID == CategoryId
                          select new ServiceVM
                          {
                              ServiceID = c.ServiceID,
                              ServiceName = c.ServiceName,
                              ServiceDescription = c.ServiceDescription,
                              ServiceStockQty = c.ServiceStockQty,
                              ServicePrice = c.ServicePrice,
                              ServiceCategoryName = k.ServiceCategoryName,
                              ServiceByteImage = c.ServiceByteImage

                          }).ToList();
            }

            return result;
        }

        public int UpdateService(Service service)
        {
            _context.Service.Update(service);
            return _context.SaveChanges();
        }
        public CartItem GetServiceCartItem(int serviceID)
        {
            Service service = _context.Service.Where(a => a.ServiceID == serviceID).SingleOrDefault();
            return new CartItem
            {
                Name = service.ServiceName,
                ByteImage = service.ServiceByteImage,
                Quantity = 1,
                ServiceID = service.ServiceID,
                ServicePrice = service.ServicePrice,
                TotalPrice = service.ServicePrice
            };
        }

    }
}
