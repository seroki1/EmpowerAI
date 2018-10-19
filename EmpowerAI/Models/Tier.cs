using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class Tier
    {
        public Tier()
        {
            Submission = new HashSet<Submission>();
        }

        public int Id { get; set; }
        public string TierName { get; set; }

        public ICollection<Submission> Submission { get; set; }
    }
}
