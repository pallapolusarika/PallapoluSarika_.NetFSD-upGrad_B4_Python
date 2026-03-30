using D30_ProductDIApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace D30_ProductDIApp.Services
{
    public class ProductService : IProductService
    {
        // In-memory product list
        private readonly List<Product> _products;

        // Constructor – initialize data once
        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Car", Price = 500000 },
                new Product { Id = 2, Name = "Bike", Price = 70000 }
            };
        }

        // 1️⃣ Get all products
        public List<Product> GetAllProducts()
        {
            return _products;
        }

        // 2️⃣ Get product by ID
        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        // 3️⃣ Add new product
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // 4️⃣ Delete product
        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}