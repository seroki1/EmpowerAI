using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class Tvdaypart
    {
        public Tvdaypart()
        {
            LocalTvTvdaypart = new HashSet<LocalTvTvdaypart>();
            NationalTvTvdaypart = new HashSet<NationalTvTvdaypart>();
        }

        public int Id { get; set; }
        public string Daypart { get; set; }

        public ICollection<LocalTvTvdaypart> LocalTvTvdaypart { get; set; }
        public ICollection<NationalTvTvdaypart> NationalTvTvdaypart { get; set; }
    }
}
