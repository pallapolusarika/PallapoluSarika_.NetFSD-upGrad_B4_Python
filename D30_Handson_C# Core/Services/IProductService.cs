using D30_ProductDIApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace D30_ProductDIApp.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void DeleteProduct(int id);
    }
}
