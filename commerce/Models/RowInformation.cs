using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class RowInformation
    {
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}