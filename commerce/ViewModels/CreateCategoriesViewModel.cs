using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using commerce.Models;

namespace commerce.ViewModels
{
    public class CreateCategoriesViewModel
    {
        [Display(Name = "Parent category")]
        public int? ParentCatId { get; set; }
        [Required]
        [Display(Name = "Category")]
        [StringLength(maximumLength: 200)]
        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}