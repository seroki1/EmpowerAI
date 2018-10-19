using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class DigitalDisplayBannerSize
    {
        public long Id { get; set; }
        public int BannerSizeId { get; set; }
        public int DigitalDisplayId { get; set; }

        public BannerSize BannerSize { get; set; }
        public DigitalDisplay DigitalDisplay { get; set; }
    }
}
