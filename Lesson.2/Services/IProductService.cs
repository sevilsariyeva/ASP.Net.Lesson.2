using Lesson._2.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson._2.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts(string key="");
        public void AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
        Task<Product> GetProductById(int id);
        public void AddProductList(List<Product> products);
    }
}
