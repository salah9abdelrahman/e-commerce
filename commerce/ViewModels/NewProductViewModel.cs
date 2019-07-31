using commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.ViewModels
{
    public class NewProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductStatus> ProductStatuses { get; set; }
    }
}