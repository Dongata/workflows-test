using System;

namespace workflows.Models
{
    public class NameNoEmptyValidation : Validation
    {
        public NameNoEmptyValidation(Guid id) : base(id, "Name", "El nombre es obligatorio")
        {
        }

        public override ValidationResult Validate(object fAO)
        {
            var type = fAO.GetType();

            var value = type.GetProperty(FieldName)?.GetValue(fAO);

            if (value is string pepe)
            {
                if (string.IsNullOrEmpty(pepe))
                {
                    return ValidationResult.AsInvalid(FailMessage);
                }
            }

            return ValidationResult.AsValid();
        }
    }
}
