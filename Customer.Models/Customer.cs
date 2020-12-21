using System;
using System.ComponentModel.DataAnnotations;

namespace Customer.Models
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
        public string Email { get; set; }
        public DateTime DateOfJoin { get; set; }
        public MemberType MemberType { get; set; }
        public Store Store { get; set; }
        public int StoreID { get; set; }
        public string Image { get; set; }
    }
}
