﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSShoppingCart.Infrastructure;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View();
        }
    }
}