using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clase3103.Src.Models;
using Microsoft.EntityFrameworkCore;


namespace Clase3103.Src.Data
{
    public class DataContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public required DbSet<Store> Stores { get; set; }
        public required DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Store)
                .WithMany(s => s.Products) // Configura la relación de uno a muchos
                .HasForeignKey(p => p.StoreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

