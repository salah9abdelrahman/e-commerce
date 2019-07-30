using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class Order : RowInformation
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CouponId { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }

    }
}