using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class NationalTv
    {
        public NationalTv()
        {
            NationalTvSpotLength = new HashSet<NationalTvSpotLength>();
            NationalTvTvdaypart = new HashSet<NationalTvTvdaypart>();
        }

        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int ChannelPreferenceId { get; set; }
        public int? BudgetPercent { get; set; }
        public string Remarks { get; set; }

        public ChannelPreference ChannelPreference { get; set; }
        public Submission Submission { get; set; }
        public ICollection<NationalTvSpotLength> NationalTvSpotLength { get; set; }
        public ICollection<NationalTvTvdaypart> NationalTvTvdaypart { get; set; }
    }
}
