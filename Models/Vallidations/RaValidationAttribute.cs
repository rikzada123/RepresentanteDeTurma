using System.ComponentModel.DataAnnotations;

namespace Turma.Models.Validations
{
    public class RaValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string ra = value as string;    

            if (string.IsNullOrEmpty(ra))
                return new ValidationResult("O RA é obrigatorio");

            if(ra.Length != 6)
                return new ValidationResult("O RA deve ter exatamente 6 digítos.");

            foreach (char c in ra)
            {
                if(!char.IsNumber(c))
                    return new ValidationResult("O RA deve ser apenas números.");
            }

            return ValidationResult.Success;
        }
    }
}