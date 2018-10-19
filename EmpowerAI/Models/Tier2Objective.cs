using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class Tier2Objective
    {
        public Tier2Objective()
        {
            Submission = new HashSet<Submission>();
        }

        public int Id { get; set; }
        public string Objective { get; set; }

        public ICollection<Submission> Submission { get; set; }
    }
}
