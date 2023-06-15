using Fixer.Models;
using Fixer.Models.VMs;
using Fixer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fixer.Controllers
{
	public class CartController : Controller
	{
		public static Cart cart = new Cart();
		public static List<CartItem> cartItems = new List<CartItem>();
		private readonly I_ServiceRepo _serviceRepo;
        public CartController(I_ServiceRepo serviceRepo)
        {
			_serviceRepo = serviceRepo;
		}

		public IActionResult AddToCart(int serviceID)
		{
			CartItem cartItem = _serviceRepo.GetServiceCartItem(serviceID);
			cartItems.Add(cartItem);
			cart.CartList = new List<CartItem>(cartItems);
			cart.CartTotal += cartItem.TotalPrice;
			return PartialView("_Cart", cart);
		}
		public IActionResult Checkout() 
		{
			return View("Checkout",cart);
		}
	}
}
