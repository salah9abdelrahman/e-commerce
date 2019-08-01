using commerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.ViewModels
{
    public class NewProductViewModel : RowInformation
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

        [Display(Name = "Status")]
        public int ProductStatusId { get; set; }

    }
}