﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commerce.Models
{
    public class Transaction : RowInformation
    {
        public int TransactionId { get; set; }
        [Display(Name = "Transaction date")]
        [Required]
        public int TransDate { get; set; }
        [Required]
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        //public string Code { get; set; }
    }
}