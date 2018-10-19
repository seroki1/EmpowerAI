using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class SearchEngine
    {
        public SearchEngine()
        {
            PaidSearchSearchEngine = new HashSet<PaidSearchSearchEngine>();
        }

        public int Id { get; set; }
        public string SearchEngineName { get; set; }

        public ICollection<PaidSearchSearchEngine> PaidSearchSearchEngine { get; set; }
    }
}
