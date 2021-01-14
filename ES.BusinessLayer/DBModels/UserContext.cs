using System;
using System.Collections.Generic;
using System.Text;
using ES.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ES.BusinessLayer.DBModels
{
    public class UserContext:DbContext
    {
        public UserContext()
        {
                
        }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=ElectronicStore;Trusted_Connection=True;");
            }
        }
    }
}
