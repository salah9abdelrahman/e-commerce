using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class Role : RowInformation
    {
        public int RoleId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}