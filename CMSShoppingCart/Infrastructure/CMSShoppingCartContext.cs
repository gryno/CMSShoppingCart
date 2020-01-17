using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSShoppingCart.Models;

namespace CMSShoppingCart.Infrastructure
{
    public class CMSShoppingCartContext : DbContext
    {
        public CMSShoppingCartContext(DbContextOptions<CMSShoppingCartContext> options) : base(options)
        {
        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
