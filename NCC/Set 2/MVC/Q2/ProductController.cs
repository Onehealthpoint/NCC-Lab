using Microsoft.AspNetCore.Mvc;
using Set2_MVC.Models;

namespace Set2_MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>
            {
                new ProductModel { Id = 1, Name = "Product 1", Price = 10.0 },
                new ProductModel { Id = 2, Name = "Product 2", Price = 20.0 },
                new ProductModel { Id = 3, Name = "Product 3", Price = 30.0 }
            };

            return Json(products);
        }
    }
}
