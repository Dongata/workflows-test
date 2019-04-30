using System;
using System.Text.RegularExpressions;

namespace workflows.Models
{
    public class FieldShouldContainOnlyNumbersValidation : Validation
    {
        private Regex regex = new Regex("\\d*");

        public FieldShouldContainOnlyNumbersValidation(Guid id, string fieldName) : base(id, fieldName, $"{fieldName} Acepta solo números")
        {
        }

        public override ValidationResult Validate(object fAO)
        {
            var type = fAO.GetType();

            var value = type.GetProperty(FieldName)?.GetValue(fAO);

            if (value is string pepe)
            {
                if (!regex.IsMatch(pepe))
                {
                    return ValidationResult.AsInvalid(FailMessage);
                }
            }

            return ValidationResult.AsValid();
        }
    }
}
