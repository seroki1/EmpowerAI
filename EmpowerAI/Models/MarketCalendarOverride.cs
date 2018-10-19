using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class MarketCalendarOverride
    {
        public MarketCalendarOverride()
        {
            MarketCalendarOverrideWeek = new HashSet<MarketCalendarOverrideWeek>();
        }

        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int Dmaid { get; set; }
        public string Remarks { get; set; }

        public Dma Dma { get; set; }
        public Submission Submission { get; set; }
        public ICollection<MarketCalendarOverrideWeek> MarketCalendarOverrideWeek { get; set; }
    }
}
