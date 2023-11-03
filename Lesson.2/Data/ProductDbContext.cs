using Lesson._2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lesson._2.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>
            contextOptions)
            : base(contextOptions)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "Cola",
                   Description = "Drink",
                   Price = 3,
                   Discount = 10,
                   ImageLink = "images\\cola.png"
               },
               new Product
            {
                Id = 2,
                Name = "Fanta",
                Description = "Drink",
                Price = 3,
                Discount = 5,
                ImageLink = "images\\fanta.png"
            },
               new Product
            {
                Id = 3,
                Name = "Ruffles",
                Description = "Chips",
                Price = 5,
                Discount = 15,
                ImageLink = "images\\ruffles.png"
            },
               new Product
               {
                   Id = 4,
                   Name = "Lays",
                   Description = "Chips",
                   Price = 4,
                   Discount = 15,
                   ImageLink = "images\\lays.png"
               }
            );
        }
        public DbSet<Product> Products { get; set; }

    }
}
