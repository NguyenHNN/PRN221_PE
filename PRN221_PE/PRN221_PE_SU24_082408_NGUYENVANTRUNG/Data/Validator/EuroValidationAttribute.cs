using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Validator
{
    public class EuroValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string artTitle)
            {
                // Check for numbers
                if (Regex.IsMatch(artTitle, @"\d"))
                {
                    return new ValidationResult("ArtTitle must not contain any numbers.");
                }

                // Check for capital letters at the beginning of each word
                var words = artTitle.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (!char.IsUpper(word[0]))
                    {
                        return new ValidationResult("Each word in ArtTitle must begin with a capital letter.");
                    }
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("ArtTitle is required.");
        }
    }
}
