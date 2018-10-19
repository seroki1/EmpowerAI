using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class Dma
    {
        public Dma()
        {
            Budget = new HashSet<Budget>();
            MarketCalendarOverride = new HashSet<MarketCalendarOverride>();
            SubmissionDma = new HashSet<SubmissionDma>();
        }

        public int Id { get; set; }
        public string Dmaname { get; set; }

        public ICollection<Budget> Budget { get; set; }
        public ICollection<MarketCalendarOverride> MarketCalendarOverride { get; set; }
        public ICollection<SubmissionDma> SubmissionDma { get; set; }
    }
}
