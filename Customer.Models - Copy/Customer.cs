using CustomerCRUD.Models.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerCRUD.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        //ver1
        //[EmailDomainValidator]
        //ver2
        //[EmailDomainValidator(AllowedDomain = "dns.com")]
        // ver 3
        [EmailDomainValidator(AllowedDomain = "dns.com", ErrorMessage ="Only dns.com allowed")]
        public string Email { get; set; }
        [CompareProperty("Email",
        ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfJoin { get; set; }
        public MemberType MemberType { get; set; }
        public Store Store { get; set; }
        public int StoreID { get; set; }
        public string Image { get; set; }
    }
}
