using System.ComponentModel.DataAnnotations;
namespace CarManufactoring.Models
{
    public class AgeValidator : ValidationAttribute
    {
        protected override ValidationResult
            IsValid(object value, ValidationContext validationContext)
            {
                DateTime dob = Convert.ToDateTime(value);
                var today = DateTime.Today;

                // Calculate the age.
                var age = today.Year - dob.Year;

                // Go back to the year in which the person was born in case of a leap year
                if (dob.Date > today.AddYears(-age)) age--;

                if (age < 18 || age > 60)
                {
                    return new ValidationResult
                        ("Enter Valid age!");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
    }
}
