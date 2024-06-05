using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_school.Models.Validations
{
    public class ValidateNextDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateOnly dateValue)
            {
                return dateValue >= DateOnly.FromDateTime(DateTime.Today);
            }
            return false;
        }
    }
}