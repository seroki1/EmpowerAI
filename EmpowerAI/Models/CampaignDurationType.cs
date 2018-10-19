using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class CampaignDurationType
    {
        public CampaignDurationType()
        {
            Submission = new HashSet<Submission>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Submission> Submission { get; set; }
    }
}
