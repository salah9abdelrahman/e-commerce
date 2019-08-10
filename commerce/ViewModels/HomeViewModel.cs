using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.ViewModels
{
    public class HomeViewModel
    {
        [Display(Name = "Customers")]
        public int CustomersCount { get; set; }
        [Display(Name = "Products")]
        public int ProductsCount { get; set; }
        [Display(Name = "Categories")]
        public int CategoriesCount { get; set; }
        [Display(Name = "Orders")]
        public int OrdersCount { get; set; }
        [Display(Name = "Coupons")]
        public int CouponsCount { get; set; }
    }
}