using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using System.Web;

namespace MVC.Models
{
    public class Payment
    {
        [Required]
        public string Name{ get; set; }
        [CreditCard]
        [Required]
        public int CreditCard { set; get; }
        [Required]
        public string PaymentType{ set; get; }
        [Required]
        public string BillingAddress{ set; get; }

        [Required] public string city { set; get; }
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Invalid Zip Code")]
        [Required]
        public string ZipCode { set; get; }
        [Required]
        [Phone]
        public string PhoneNumber{ set; get; }
    }
    public enum PaymentType{ Visa,MasterCard}
}