using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class PaidSearchSearchEngine
    {
        public long Id { get; set; }
        public int SearchEngineId { get; set; }
        public int PaidSearchId { get; set; }

        public PaidSearch PaidSearch { get; set; }
        public SearchEngine SearchEngine { get; set; }
    }
}
