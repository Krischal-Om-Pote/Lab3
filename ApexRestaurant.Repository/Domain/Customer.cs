using System;
using Microsoft.AspNetCore.Http;

namespace ApexRestaurant.Repository.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public string? PhoneRes { get; set; }
        public required string PhoneMob { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}