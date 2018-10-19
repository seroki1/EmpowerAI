using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class SpotLength
    {
        public SpotLength()
        {
            LocalTvSpotLength = new HashSet<LocalTvSpotLength>();
            NationalTvSpotLength = new HashSet<NationalTvSpotLength>();
        }

        public int Id { get; set; }
        public string SpotLength1 { get; set; }

        public ICollection<LocalTvSpotLength> LocalTvSpotLength { get; set; }
        public ICollection<NationalTvSpotLength> NationalTvSpotLength { get; set; }
    }
}
