using Lesson._2.Services;
using Microsoft.AspNetCore.Mvc;
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

         public async Task<IActionResult> Index(string key = "")
        {
            var result = await _productService.GetAllByKey(key);
            return Ok(result);
        }
    }
}
