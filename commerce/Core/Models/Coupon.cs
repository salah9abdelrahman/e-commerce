using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class Coupon : RowInformation
    {
        public Coupon()
        {
            Orders = new HashSet<Order>();
        }
        public int CouponId { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Order> Orders { get; set; }

        //public bool Multiple { get; set; }
    }
}