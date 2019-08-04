using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class Product : RowInformation
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product")]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Product description")]
        public string Description { get; set; }

        [Display(Name = " Regular price")]
        public decimal RegularPrice { get; set; }
        [Display(Name = " Discount price")]
        public decimal DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public int ProductStatusId { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }


    }
}