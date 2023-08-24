using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
	public class ProductFilterMenuViewComponent : ViewComponent
	{
		//Or IActionResult doesnt matter
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
