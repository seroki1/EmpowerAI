using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class LocalTv
    {
        public LocalTv()
        {
            LocalTvSpotLength = new HashSet<LocalTvSpotLength>();
            LocalTvTvdaypart = new HashSet<LocalTvTvdaypart>();
        }

        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int ChannelPreferenceId { get; set; }
        public int? BudgetPercent { get; set; }
        public string Remarks { get; set; }

        public ChannelPreference ChannelPreference { get; set; }
        public Submission Submission { get; set; }
        public ICollection<LocalTvSpotLength> LocalTvSpotLength { get; set; }
        public ICollection<LocalTvTvdaypart> LocalTvTvdaypart { get; set; }
    }
}
