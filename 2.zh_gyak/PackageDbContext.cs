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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ProductPackage");
        }

        // memóriában futó adatbázist használunk, nem valódi fizikai DB-t - Ideális teszteléshez vagy prototípushoz, mert nem ír fájlba vagy SQL Server-be
    }
}
