using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace commerce.Core.Models
{
    public class ProductStatus : RowInformation
    {
        public ProductStatus()
        {
            Products = new HashSet<Product>();
        }
        public int ProductStatusId { get; set; }
        [Required]
        [Display(Name = "Status")]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}