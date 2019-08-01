using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class Category : RowInformation
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }
        public int CategoryId { get; set; }
        public int ParentCatId { get; set; }
        [Required]
        [Display(Name = "Category")]
        [StringLength(maximumLength: 200)]
        public string Name { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

    }
}