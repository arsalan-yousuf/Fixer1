using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fixer.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ServiceStockQty { get; set; }
        public int ServicePrice { get; set; }
        public int ServiceCategoryID { get; set; }

        [NotMapped]
        public IFormFile ServicePicture { get; set; }
        public byte[] ServiceByteImage { get; set; }
    }
}
