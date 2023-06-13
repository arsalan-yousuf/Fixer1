using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fixer.Areas.Identity.Data;
using Fixer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fixer.Areas.Identity.Data
{
    public class FixerContext : IdentityDbContext<FixerUser>
    {
        public FixerContext(DbContextOptions<FixerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ServiceCategory> Service_Category { get; set; }
        public DbSet<Service> Service { get; set; }
    }
}
