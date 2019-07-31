using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class ProductCategory : RowInformation
    {
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

    }
}