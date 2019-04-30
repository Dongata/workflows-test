using System;

namespace workflows.Models
{
    public abstract class Validation
    {
        protected Validation(Guid id, string fieldName, string failMessage)
        {
            Id = id;
            FieldName = fieldName;
            FailMessage = failMessage;
        }

        public Guid Id { get; set; }
        public string FieldName { get; set; }
        public string FailMessage { get; set; }

        public abstract ValidationResult Validate(object fAO);
    }
}