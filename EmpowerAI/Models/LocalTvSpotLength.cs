using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class LocalTvSpotLength
    {
        public long Id { get; set; }
        public int LocalTvid { get; set; }
        public int SpotLengthId { get; set; }

        public LocalTv LocalTv { get; set; }
        public SpotLength SpotLength { get; set; }
    }
}
