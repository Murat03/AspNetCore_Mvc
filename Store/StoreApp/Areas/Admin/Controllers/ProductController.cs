using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Concrete;
using Services.Contracts;
using StoreApp.Models;
using System.Data;

namespace StoreApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ProductController : Controller
	{
		private readonly IServiceManager _manager;
		public ProductController(IServiceManager manager, IMapper mapper)
		{
			_manager = manager;
		}

		public IActionResult Index([FromQuery] ProductRequestParameters p)
		{
			ViewData["Title"] = "Products";
			var products = _manager.ProductService.GetAllProductsWithDetails(p);
			var pagination = new Pagination()
			{
				CurrentPage = p.PageNumber,
				ItemsPerPage = p.PageSize,
				TotalItems = _manager.ProductService.GetAllProducts(false).Count()
			};
			return View(new ProductListViewModel()
			{
				Products = products,
				Pagination = pagination
			});
		}
		public IActionResult Create()
		{
			TempData["info"] = "Please fill the form.";
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
			TempData["success"] = $"{productDto.ProductName} has been created.";
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
			ViewData["Title"] = productDto?.ProductName;
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
			TempData["danger"] = "The product has been removed.";
			return RedirectToAction("Index");
		}
	}
}
