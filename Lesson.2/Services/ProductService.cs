using Lesson._2.Entities;
using Lesson._2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson._2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddAsync(product);
        }
        public void AddProductList(List<Product> products)
        {
            _productRepository.AddRangeAsync(products);
        }
        public async Task<List<Product>> GetAllProducts(string key = "")
        {
           var data=await _productRepository.GetAllAsync();
            return key != "" ? data.Where(s => s.Name.ToLower().Contains(key.ToLower())).ToList()
                :data;
        }

        public async Task<Product> GetProductById(int id)
        {
            var products = _productRepository.GetAllAsync();
            var productList = await products;
            var product= productList.FirstOrDefault(p=>p.Id==id);
            return product;
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }
    }
}
