using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class NationalTvSpotLength
    {
        public long Id { get; set; }
        public int NationalTvid { get; set; }
        public int SpotLengthId { get; set; }

        public NationalTv NationalTv { get; set; }
        public SpotLength SpotLength { get; set; }
    }
}
