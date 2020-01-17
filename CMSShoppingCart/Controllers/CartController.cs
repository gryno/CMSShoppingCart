using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSShoppingCart.Infrastructure;
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
            return View();
        }
    }
}