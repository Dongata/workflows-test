using System;
using System.Collections.Generic;

namespace workflows.Models
{
    public class Change
    {
        public Change(Guid id, string name, State initialState, State finalState, IList<Validation> validations = null)
        {
            Id = id;
            Name = name;
            InitialState = initialState;
            FinalState = finalState;
            Validations = validations ?? new List<Validation>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public State InitialState { get; set; }
        public State FinalState { get; set; }
        public IList<Validation> Validations { get; set; }

        public ValidationResult Validate(IMaintanState fAO)
        {
            foreach (var validation in Validations)
            {
                var result = validation.Validate(fAO);

                if(!result.IsValid)
                {
                    return result;
                }
            }

            return ValidationResult.AsValid();
        }
    }
}
