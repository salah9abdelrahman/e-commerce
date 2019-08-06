using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace commerce.Core.Models
{
    public class Role : RowInformation
    {
        public Role()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
        }
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Role")]
        [StringLength(maximumLength: 70)]
        public string Name { get; set; }
        public virtual IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}