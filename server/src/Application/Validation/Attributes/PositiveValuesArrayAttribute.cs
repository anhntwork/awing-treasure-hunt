using System.ComponentModel.DataAnnotations;

namespace Application.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class PositiveValuesArrayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int[][] array)
            {
                foreach (var row in array)
                {
                    if (row == null || row.Any(v => v <= 0))
                    {
                        return new ValidationResult("All values in the array must be greater than 0.");
                    }
                }
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid type. The attribute can only be used with int[][].");
        }
    }
}
