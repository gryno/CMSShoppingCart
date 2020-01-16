﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSShoppingCart.Models
{
    public class Page
    {
        public int Id { get; set; }
        [Required, MinLength(2, ErrorMessage ="Minimum length of 2 characters")]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Minimum length of 4 characters")]
        public string Content { get; set; }
        public int Sorting { get; set; }

    }
}
