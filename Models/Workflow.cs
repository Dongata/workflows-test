using System;
using System.Collections.Generic;
using System.Linq;

namespace workflows.Models
{
    public class Workflow
    {
        public Workflow(Guid id, string name, IList<Change> changes)
        {
            Id = id;
            Name = name;
            Changes = changes;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Change> Changes { get; set; }

        public bool ChangeState(IMaintanState fAO, State newState)
        {
            var change = Changes.FirstOrDefault(
                c => c.InitialState == fAO.State
                && c.FinalState == newState);

            if(change == null)
            {
                throw new Exception("Cambio de estado no admitido");
            }

            var result = change.Validate(fAO);

            if(result.IsValid)
            {
                return true;
            }

            throw new Exception(result.Message);
        }
    }
}
