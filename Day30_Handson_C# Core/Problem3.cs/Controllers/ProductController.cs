using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProductApp.Controllers   // ⚠️ change if your project name is different
{
    [Route("product")]
    public class ProductController : Controller
    {
        // ✅ Static list
        public static List<dynamic> productList = new List<dynamic>();

        // ✅ GET method
        [HttpGet("add")]
        public IActionResult Add()
        {
            ViewBag.Products = productList;
            return View();
        }

        // ✅ POST method
        [HttpPost("add")]
        public IActionResult Add(string name, int price, int quantity)
        {
            productList.Add(new
            {
                Name = name,
                Price = price,
                Quantity = quantity
            });

            ViewBag.Products = productList;
            return View();
        }
    }
}