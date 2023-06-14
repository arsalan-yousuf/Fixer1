using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fixer.Models.VMs
{
    public class ServiceVM
    {
        [Key]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ServiceStockQty { get; set; }
        public int ServicePrice { get; set; }
        public string ServiceCategoryName { get; set; }
        public byte[] ServiceByteImage { get; set; }
    }
}
