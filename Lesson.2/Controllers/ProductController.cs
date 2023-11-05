using Lesson._2.Entities;
using Lesson._2.Models;
using Lesson._2.Repositories;
using Lesson._2.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Lesson._2.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWebHostEnvironment webHostEnvironment, IProductService productService)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }

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
        public IActionResult Add(ProductAddViewModel vm, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }
                    vm.Product.ImageLink = $"images\\{uniqueFileName}";
                    _productService.AddProduct(vm.Product);
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
        }


    }
}
