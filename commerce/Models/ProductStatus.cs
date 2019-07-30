using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class ProductStatus
    {
        public int ProductStatusId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}