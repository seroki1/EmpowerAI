using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class NationalTvTvdaypart
    {
        public long Id { get; set; }
        public int NationalTvid { get; set; }
        public int TvdaypartId { get; set; }

        public NationalTv NationalTv { get; set; }
        public Tvdaypart Tvdaypart { get; set; }
    }
}
