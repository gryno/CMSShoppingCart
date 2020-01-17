using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSShoppingCart.Infrastructure;
using CMSShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMSShoppingCart.Controllers
{
    public class CartController : Controller
    {
        private readonly CMSShoppingCartContext context;

        public CartController(CMSShoppingCartContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartViewModel = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };


            return View(cartViewModel);
        }
    }
}