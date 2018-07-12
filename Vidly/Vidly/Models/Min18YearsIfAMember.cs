using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeID == MembershipType.PayAsYouGo || customer.MembershipTypeID == MembershipType.Unknown)
            {
                return ValidationResult.Success;
            }
            else if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var temp = DateTime.Now - customer.BirthDate;
            var age = temp.Value.TotalDays / 365.23;

            return (age >= 18) ?
                ValidationResult.Success :
                new ValidationResult("Customer should be atleast 18 years old to go on membership");
        }
    }
}