using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Entities.RequestParameters;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager service)
        {
            _serviceManager = service;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            var model = _serviceManager.ProductService.GetAllProductsWithDetails(p);
            return View(model);
        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _serviceManager.ProductService.GetOneProduct(id, false);
            return View(model);
        }
    }
}