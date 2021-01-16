using System;
using System.Collections.Generic;
using System.Text;
using ES.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ES.BusinessLayer.DBModels
{
    public class ShopContext:DbContext
    {
        public ShopContext()
        {
            
        }

        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
        }

        public virtual DbSet<ElectroProducts> ElectroProducts { get; set; }
        public virtual DbSet<ElectroCategories> ElectroCategories { get; set; }
        public virtual DbSet<ElectroBrands> ElectroBrands { get; set; }
        public virtual DbSet<ApplianceProducts> ApplianceProducts { get; set; }
        public virtual DbSet<ApplianceCategories> ApplianceCategories { get; set; }
        public virtual DbSet<ApplianceBrands> ApplianceBrands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=ElectronicStore;Trusted_Connection=True;");
            }
        }
    }
}
