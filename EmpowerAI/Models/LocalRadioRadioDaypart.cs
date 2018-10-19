using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class LocalRadioRadioDaypart
    {
        public long Id { get; set; }
        public int RadioDaypartId { get; set; }
        public int LocalRadioId { get; set; }

        public LocalRadio LocalRadio { get; set; }
        public RadioDaypart RadioDaypart { get; set; }
    }
}
