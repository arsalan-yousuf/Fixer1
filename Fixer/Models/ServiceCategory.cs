using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fixer.Models
{
    public class ServiceCategory
    {
        [Key]
        public int ServiceCategoryID { get; set; }
        public string ServiceCategoryName { get; set; }
        public string ServiceCategoryDescription { get; set;}
        [NotMapped]
        public IFormFile ServiceCategoryPicture { get; set; }
        public byte[] ServiceCategoryByteImage { get; set; }
    }
}
