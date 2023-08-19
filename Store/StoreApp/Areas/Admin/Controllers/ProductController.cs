using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IServiceManager _manager;
		public ProductController(IServiceManager manager, IMapper mapper)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var model = _manager.ProductService.GetAllProducts(false);
			return View(model);
		}
		public IActionResult Create()
		{
			ViewBag.Categories = GetCategoriesSelectList();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			//File operation
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",file.FileName); // a/b/c

			using (var stream = new FileStream(path,FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			productDto.ImageUrl = String.Concat("/images/",file.FileName);
			_manager.ProductService.CreateProduct(productDto);
			return RedirectToAction("Index");
		}
		private SelectList GetCategoriesSelectList()
		{
			return new SelectList(_manager.CategoryService.GetAllCategories(false),
				"CategoryId", "CategoryName", 1);
		}
		public IActionResult Update([FromRoute(Name ="id")] int id)
		{
			ViewBag.Categories = GetCategoriesSelectList();
			var productDto = _manager.ProductService.GetOneProductForUpdate(id, false);
			return View(productDto);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
		{
			if(ModelState.IsValid)
			{
				//File operation
				string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName); // a/b/c

				using (var stream = new FileStream(path, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				productDto.ImageUrl = String.Concat("/images/", file.FileName);
				_manager.ProductService.UpdateOneProduct(productDto);
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public IActionResult Delete([FromRoute(Name ="id")]int id)
		{
			_manager.ProductService.DeleteOneProduct(id);
			return RedirectToAction("Index");
		}
	}
}
