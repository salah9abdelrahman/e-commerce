using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class Product : RowInformation
    {
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public int ProductStatusId { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }


    }
}