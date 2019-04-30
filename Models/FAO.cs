using System;

namespace workflows.Models
{
    public class FAO : IMaintanState
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Pepe { get; set; }

        public State State { get; set; }

        public Workflow Workflow { get; set; }

        public void ApplyState(State newState)
        {
            if (Workflow.ChangeState(this, newState))
            {
                State = newState;
            }
        }
    }
}
