using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class AudienceDemographic
    {
        public long Id { get; set; }
        public int AudienceId { get; set; }
        public int DemographicId { get; set; }

        public Audience Audience { get; set; }
        public Demographic Demographic { get; set; }
    }
}
