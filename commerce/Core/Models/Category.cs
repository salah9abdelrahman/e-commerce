using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace commerce.Core.Models
{
    public class Category : RowInformation
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int CategoryId { get; set; }

        [Display(Name = "Parent category")]
        public int? ParentCatId { get; set; }
        [Required]
        [Display(Name = "Category")]
        [StringLength(maximumLength: 200)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}