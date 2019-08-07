using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.ViewModels
{
    public class CustomerViewModel
    {
        public string UserId { get; set; }

        [StringLength(100)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Type")]
        public string RegisterAs { get; set; }
        [Display(Name = "Creation time")]
        public DateTime CreationTime { get; set; }
        [Display(Name = "Updated time")]
        public DateTime? UpdatedTime { get; set; }
        public string UserName { get; set; }
    }
}