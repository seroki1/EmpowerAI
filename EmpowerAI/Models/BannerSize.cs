using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class BannerSize
    {
        public BannerSize()
        {
            DigitalDisplayBannerSize = new HashSet<DigitalDisplayBannerSize>();
        }

        public int Id { get; set; }
        public string BannerSize1 { get; set; }

        public ICollection<DigitalDisplayBannerSize> DigitalDisplayBannerSize { get; set; }
    }
}
