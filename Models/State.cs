using System;

namespace workflows.Models
{
    public class State
    {
        public State(Guid id, string name, bool isFinal, bool isApproved)
        {
            Id = id;
            Name = name;
            IsFinal = isFinal;
            IsApproved = isApproved;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsFinal { get; set; }
        public bool IsApproved { get; set; }
    }
}
