using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace CarManufactoring.Models
{
    public class CollaboratorStatusValidator : ValidationAttribute
    {

        protected override ValidationResult

        IsValid(object value, ValidationContext validationContext)
        {
            var status = validationContext.ObjectType.GetProperty("Status");
            bool Onduty = Convert.ToBoolean(value);

            var statusValue = (string)status.GetValue(validationContext.ObjectInstance);

            if (Onduty && statusValue == "Available")
            {
                return new ValidationResult
                    ("Collaborator can not be on duty and available at the same time!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}

