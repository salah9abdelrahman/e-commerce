using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace commerce.Core.Models
{
    public class Order : RowInformation
    {
        public Order()
        {
            Transactions = new HashSet<Transaction>();
            OrderProducts = new HashSet<OrderProduct>();
        }
        public int OrderId { get; set; }
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }
        public int CouponId { get; set; }
        public virtual Coupon Coupon { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}