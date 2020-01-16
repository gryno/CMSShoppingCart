using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSShoppingCart.Infrastructure;
using CMSShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CMSShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly CMSShoppingCartContext context;


        public ProductsController(CMSShoppingCartContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Product.OrderByDescending(x => x.Id).Include(x => x.Category).ToListAsync().ConfigureAwait(false));
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(context.Categories.OrderBy(x => x.Sorting), "Id", "Name");

            return View();
        }
    }
}