﻿using System.ComponentModel.DataAnnotations;

namespace commerce.Core.Models
{
    public class OrderProduct : RowInformation
    {
        public int OrderProductId { get; set; }
        public int ProductId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }


        //public demical SubTotal { get; set; }

    }
}