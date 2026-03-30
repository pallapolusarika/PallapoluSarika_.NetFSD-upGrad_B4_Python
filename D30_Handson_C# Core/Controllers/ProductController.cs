using Microsoft.AspNetCore.Mvc;
using D30_ProductDIApp.Models;
using D30_ProductDIApp.Services;

namespace D30_ProductDIApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //  Display list
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        //  Add product - GET
        public IActionResult Create()
        {
            return View();
        }

        //  Add product - POST
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}