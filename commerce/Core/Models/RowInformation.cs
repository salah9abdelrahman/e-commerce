using System;
using System.ComponentModel.DataAnnotations;

namespace commerce.Core.Models
{
    public class RowInformation
    {
        public bool IsDeleted { get; set; } = false;
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