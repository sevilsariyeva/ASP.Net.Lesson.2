using Lesson._2.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson._2.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts(string key="");
        public void AddProduct(Product product);
        public void AddProductList(List<Product> products);
    }
}
