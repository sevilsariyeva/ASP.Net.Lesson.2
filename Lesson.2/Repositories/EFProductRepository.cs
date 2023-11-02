using Lesson._2.Data;
using Lesson._2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson._2.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public EFProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Product product)
        {
           await _dbContext.Products.AddAsync(product); 
           await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

    }
}
