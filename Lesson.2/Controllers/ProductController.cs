using Lesson._2.Entities;
using Lesson._2.Models;
using Lesson._2.Repositories;
using Lesson._2.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Lesson._2.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;

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
           [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product(),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(vm.Product);
                return RedirectToAction("index");
            }
            return View(vm);
        }
        [HttpPost]
        [Route("/Upload")]
        public IActionResult UploadImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                // Construct and return the relative path to the uploaded image
                var relativePath = Path.Combine("uploads", fileName);
                return Json(new { filePath = relativePath });
            }

            return Json(new { error = "No image uploaded" });
        }
    }
}
