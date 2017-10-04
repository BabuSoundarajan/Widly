using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Widly.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId==MemberShipType.Unknown || customer.MembershipTypeId == MemberShipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birth date is required.");

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return (age > 18) ? ValidationResult.Success : new ValidationResult("Age should be greater than 18 to become a member.");
        }
    }
}