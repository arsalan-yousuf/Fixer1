using Fixer.Models;
using Fixer.Models.VMs;

namespace Fixer.Repositories
{
    public interface I_ServiceRepo
    {
        public int CreateService(Service service);
        public int UpdateService(Service service);
        public int DeleteService(int serviceId);
        public List<ServiceVM> GetServiceByCategory(int CategoryId);
        public List<Service> GetAllService(string sortOrder);
        public CartItem GetServiceCartItem(int serviceID);
    }
}
