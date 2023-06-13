using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Fixer.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the FixerUser class
    public class FixerUser : IdentityUser
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [NotMapped]
        public string Full_Name
        {
            get
            {
                return First_Name + " " + Last_Name;
            }
        }
    }
}
