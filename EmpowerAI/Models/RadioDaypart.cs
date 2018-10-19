using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class RadioDaypart
    {
        public RadioDaypart()
        {
            LocalRadioRadioDaypart = new HashSet<LocalRadioRadioDaypart>();
            NationalRadioRadioDaypart = new HashSet<NationalRadioRadioDaypart>();
        }

        public int Id { get; set; }
        public string Daypart { get; set; }

        public ICollection<LocalRadioRadioDaypart> LocalRadioRadioDaypart { get; set; }
        public ICollection<NationalRadioRadioDaypart> NationalRadioRadioDaypart { get; set; }
    }
}
