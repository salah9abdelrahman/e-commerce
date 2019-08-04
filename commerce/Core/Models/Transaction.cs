using System.ComponentModel.DataAnnotations;

namespace commerce.Core.Models
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