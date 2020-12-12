using BilgeAdam.Contracts;
using BilgeAdam.Services;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVC.QuickStart.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var service = new ProductService();
            var products = service.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductInputViewModel data)
        {
            var svc = new ProductService();
            var isSaved = svc.Save(data);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var svc = new ProductService();
            var product = svc.GetProduct(id);
            return View(product);
        }
    }
}