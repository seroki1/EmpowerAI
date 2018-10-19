using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class Demographic
    {
        public Demographic()
        {
            AudienceDemographic = new HashSet<AudienceDemographic>();
        }

        public int Id { get; set; }
        public string Demographic1 { get; set; }

        public ICollection<AudienceDemographic> AudienceDemographic { get; set; }
    }
}
