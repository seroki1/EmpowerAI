using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class ChannelPreference
    {
        public ChannelPreference()
        {
            DigitalDisplay = new HashSet<DigitalDisplay>();
            LocalRadio = new HashSet<LocalRadio>();
            LocalTv = new HashSet<LocalTv>();
            NationalRadio = new HashSet<NationalRadio>();
            NationalTv = new HashSet<NationalTv>();
            OnlineRadio = new HashSet<OnlineRadio>();
            OnlineVideo = new HashSet<OnlineVideo>();
            OutOfHome = new HashSet<OutOfHome>();
            PaidSearch = new HashSet<PaidSearch>();
            PaidSocial = new HashSet<PaidSocial>();
            PrintMedia = new HashSet<PrintMedia>();
        }

        public int Id { get; set; }
        public string ChannelPreference1 { get; set; }

        public ICollection<DigitalDisplay> DigitalDisplay { get; set; }
        public ICollection<LocalRadio> LocalRadio { get; set; }
        public ICollection<LocalTv> LocalTv { get; set; }
        public ICollection<NationalRadio> NationalRadio { get; set; }
        public ICollection<NationalTv> NationalTv { get; set; }
        public ICollection<OnlineRadio> OnlineRadio { get; set; }
        public ICollection<OnlineVideo> OnlineVideo { get; set; }
        public ICollection<OutOfHome> OutOfHome { get; set; }
        public ICollection<PaidSearch> PaidSearch { get; set; }
        public ICollection<PaidSocial> PaidSocial { get; set; }
        public ICollection<PrintMedia> PrintMedia { get; set; }
    }
}
