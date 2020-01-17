using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSShoppingCart.Infrastructure;
using CMSShoppingCart.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CMSShoppingCartContext context;

        public ProductsController(CMSShoppingCartContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 6;
            var products = context.Products.OrderByDescending(x => x.Id)
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize);

            ViewBag.PageNumber = page;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Count() / pageSize);

            return View(await products.ToListAsync().ConfigureAwait(false));
        }

        public async Task<IActionResult> ProductsByCategory(string categorySlug, int page = 1)
        {
            Category category = await context.Categories.Where(x => x.Slug == categorySlug)
                                                        .FirstOrDefaultAsync()
                                                        .ConfigureAwait(false);

            if (category == null)
            {
                return RedirectToAction("Index");
            }
            int pageSize = 2;
            var products = context.Products.OrderByDescending(x => x.Id)
                                           .Where(x => x.CategoryId == category.Id)
                                           .Skip((page - 1) * pageSize)
                                           .Take(pageSize);

            ViewBag.PageNumber = page;
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug = category.Slug;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)context.Products.Where(x => x.CategoryId == category.Id).Count() / pageSize);
            ViewBag.CategoryName = category.Name;

            return View(await products.ToListAsync().ConfigureAwait(false));

        }

    }
}