using Lesson._2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson._2.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>
            contextOptions)
            : base(contextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
