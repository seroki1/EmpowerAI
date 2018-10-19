using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class NationalRadioRadioDaypart
    {
        public long Id { get; set; }
        public int NationalRadioId { get; set; }
        public int RadioDaypartId { get; set; }

        public NationalRadio NationalRadio { get; set; }
        public RadioDaypart RadioDaypart { get; set; }
    }
}
