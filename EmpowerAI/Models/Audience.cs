using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class Audience
    {
        public Audience()
        {
            AudienceDemographic = new HashSet<AudienceDemographic>();
        }

        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public string DigitalAudiences { get; set; }

        public Submission Submission { get; set; }
        public ICollection<AudienceDemographic> AudienceDemographic { get; set; }
    }
}
