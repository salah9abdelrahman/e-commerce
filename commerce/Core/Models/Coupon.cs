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
        [Display(Name = "Coupon code")]
        [StringLength(maximumLength: 70)]
        public string Code { get; set; }

        [StringLength(maximumLength: 250)]
        public string Description { get; set; }

        [Display(Name = "Availability")]
        public bool Active { get; set; }

        public int Value { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        public ICollection<Order> Orders { get; set; }

        //public bool Multiple { get; set; }
    }
}