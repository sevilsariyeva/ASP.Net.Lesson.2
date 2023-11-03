using Lesson._2.Entities;
using Lesson._2.Models;
using Lesson._2.Repositories;
using Lesson._2.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson._2.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //List<Product> products = new List<Product>
        //    {
        //    new Product
        //    {
        //        Id=1,
        //        Name="Cola",
        //        Description="Drink",
        //        Price=3,
        //        Discount=10,
        //        ImageLink="/wwwroot/images/cola.png"
        //    },
        //    new Product
        //    {   Id=2,
        //        Name="Fanta",
        //        Description="Drink",
        //        Price=3,
        //        Discount=5,
        //        ImageLink="/wwwroot/images/fanta.png"
        //    },
        //    new Product
        //    {   Id=3,
        //        Name="Ruffles",
        //        Description="Chips",
        //        Price=5,
        //        Discount=15,
        //        ImageLink="/wwwroot/images/ruffles.png"
        //    },
        //    new Product
        //    {   Id=4,
        //        Name="Lays",
        //        Description="Chips",
        //        Price=4,
        //        Discount=15,
        //        ImageLink="/wwwroot/images/lays.png"
        //    }
        //};

        public async Task<IActionResult> Index()
        {
            var allProducts = await _productService.GetAllProducts();
            var model = new ProductViewModel
            {
                Products = allProducts
            };
            return View(model);
        }
     
    }
}
