using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSShoppingCart.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum length of 2 characters")]
        [RegularExpression(@"^[a-zA-Z-]+$", ErrorMessage = "Only letters allowed.")]
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Sorting { get; set; }

    }
}
