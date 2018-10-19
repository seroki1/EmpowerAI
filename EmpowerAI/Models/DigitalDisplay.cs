using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class DigitalDisplay
    {
        public DigitalDisplay()
        {
            DigitalDisplayBannerSize = new HashSet<DigitalDisplayBannerSize>();
        }

        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int ChannelPreferenceId { get; set; }
        public int? BudgetPercent { get; set; }
        public string Remarks { get; set; }

        public ChannelPreference ChannelPreference { get; set; }
        public Submission Submission { get; set; }
        public ICollection<DigitalDisplayBannerSize> DigitalDisplayBannerSize { get; set; }
    }
}
