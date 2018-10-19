using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class LocalTvTvdaypart
    {
        public long Id { get; set; }
        public int LocalTvid { get; set; }
        public int TvdaypartId { get; set; }

        public LocalTv LocalTv { get; set; }
        public Tvdaypart Tvdaypart { get; set; }
    }
}
