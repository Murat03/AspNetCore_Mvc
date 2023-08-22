using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
		public Cart Cart { get; set; } //IoC
		public CartModel(IServiceManager manager, Cart cartService)
		{
			_manager = manager;
            Cart = cartService;
		}
        
		public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/"; //Empty check
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(productId, false);

            if(product is not null)
            {
				Cart.AddItem(product, 1);
				//HttpContext.Session.SetJson<Cart>("cart", Cart);
            }
            return RedirectToPage(new {returnUrl = returnUrl}); //return Url
        }
        public IActionResult OnPostRemove(int id, string returnUrl)
        {
			Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
			//HttpContext.Session.SetJson<Cart>("cart", Cart);
			return Page();
        }
    }
}