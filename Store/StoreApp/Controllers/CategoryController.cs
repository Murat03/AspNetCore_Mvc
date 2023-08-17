using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager _serviceManager;
		public CategoryController(IServiceManager service)
		{
			_serviceManager = service;
		}
		public IActionResult Index()
        {
            var model = _serviceManager.CategoryService.GetAllCategories(false);
            return View(model);
        }
    }
}