using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
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
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}