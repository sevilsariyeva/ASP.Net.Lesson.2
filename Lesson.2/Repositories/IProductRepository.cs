using Lesson._2.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson._2.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task Add(Product product);
    }
}
