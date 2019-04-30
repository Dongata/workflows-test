using System;
using System.Collections.Generic;
using System.Text;

namespace workflows.Models
{
    public class AlwaysTrueValidation : Validation
    {
        public AlwaysTrueValidation(Guid id, string fieldName, string failMessage) : base(id, fieldName, failMessage)
        {
        }

        public override ValidationResult Validate(object fAO) => ValidationResult.AsValid();
    }
}
