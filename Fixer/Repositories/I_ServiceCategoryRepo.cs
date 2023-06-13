using Fixer.Models;
using System.Numerics;

namespace Fixer.Repositories
{
    public interface I_ServiceCategoryRepo
    {
        public int CreateServiceCategory(ServiceCategory servCat);
        public int UpdateServiceCategory(ServiceCategory servCat);
        public int DeleteServiceCategory(int servCatId);
        public List<ServiceCategory> GetAllServiceCategory(string sortOrder);
        //List<DoctorVM> DoctByDeptorDay(int deptId, string day);
    }
}
