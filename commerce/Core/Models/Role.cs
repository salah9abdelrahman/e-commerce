﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class Role : RowInformation
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public int RoleId { get; set; }

        [Required]
        [Display(Name = "Role")]
        [StringLength(maximumLength: 70)]
        public string Name { get; set; }
        public int UserRoleId { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}