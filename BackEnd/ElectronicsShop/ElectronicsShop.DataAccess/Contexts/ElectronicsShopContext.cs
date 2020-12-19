using ElectronicsShop.DataAccess.Mappings;
using ElectronicsShop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.DataAccess.Contexts
{

    public interface IElectronicsShopContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
    public class ElectronicsShopContext : DbContext, IElectronicsShopContext
    {
        public ElectronicsShopContext(DbContextOptions<ElectronicsShopContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
