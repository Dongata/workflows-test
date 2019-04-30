using System;

namespace workflows.Models
{
    public class AlwaysInvalidValidation : Validation
    {
        public AlwaysInvalidValidation(Guid id, string fieldName, string failMessage) : base(id, fieldName, failMessage)
        {
        }

        public override ValidationResult Validate(object fAO) => ValidationResult.AsInvalid("Sos un inválido, gato");
    }
}
