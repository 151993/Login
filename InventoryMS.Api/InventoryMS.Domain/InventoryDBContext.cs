using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryMS.Domain
{
    public class InventoryDBContext: DbContext
    {
        public InventoryDBContext()
        {
        }
        public InventoryDBContext(DbContextOptions<InventoryDBContext> options)
            : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=EPINPUNW00B0; Database=ERTHMNY; Trusted_Connection=True;");
            }
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
