using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class RowInformation
    {
        public bool? IsDeleted { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Creation time")]
        public DateTime CreationTime { get; set; }
        [Display(Name = "Updated time")]
        public DateTime? UpdatedTime { get; set; }
    }
}