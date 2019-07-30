using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int ParentCatId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}