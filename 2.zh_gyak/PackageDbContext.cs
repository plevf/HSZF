using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.zh_gyak
{
    public class PackageDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public PackageDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


    }
}
