using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class MarketCalendarOverrideWeek
    {
        public int Id { get; set; }
        public int MarketCalendarOverrideId { get; set; }
        public DateTime WeekOf { get; set; }
        public bool Priority { get; set; }
        public bool Dark { get; set; }
        public bool NewCreative { get; set; }
        public string Explanation { get; set; }

        public MarketCalendarOverride MarketCalendarOverride { get; set; }
    }
}
