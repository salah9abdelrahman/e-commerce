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
        public int CategoryId { get; set; }
        [Display(Name = "Parent category")]

        public int? ParentCatId { get; set; }
        [Required]
        [Display(Name = "Category")]
        [StringLength(maximumLength: 200)]
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Creation time")]
        public DateTime CreationTime { get; set; }

    }
}