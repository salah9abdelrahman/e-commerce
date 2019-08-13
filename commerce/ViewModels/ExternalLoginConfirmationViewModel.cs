using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace commerce.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }

        [Required] [StringLength(100)] [Display(Name = "First name")] public string FirstName { get; set; }

        [Required] [StringLength(100)] [Display(Name = "Last name")] public string LastName { get; set; }

        [Display(Name = "Phone number")] public string PhoneNumber { get; set; }

    }
}