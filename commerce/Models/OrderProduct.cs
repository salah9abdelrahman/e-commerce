using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class OrderProduct : RowInformation
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }


        //public demical SubTotal { get; set; }

    }
}