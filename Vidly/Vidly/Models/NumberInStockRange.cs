using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class NumberInStockRange :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.NumberInStock == null)
            {
                return new ValidationResult("The Number in Stock is required.");
            }
            else if (movie.NumberInStock >= 1 && movie.NumberInStock <= 50)
            {
                return ValidationResult.Success;
            }
            else
            {
                var str = "The field in Number in Stock must be between " + Movie.NISmin + " and " + Movie.NISmax;
                return new ValidationResult(str);
            }
        }
    }
}