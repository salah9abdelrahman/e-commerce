using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using commerce.Models;

namespace commerce.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Display(Name = "Parent category")]
        public string ParentCatName { get; set; }
        [Required]
        [Display(Name = "Category")]
        [StringLength(maximumLength: 200)]
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}