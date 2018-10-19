using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class PaidSocialSocialMedia
    {
        public long Id { get; set; }
        public int PaidSocialId { get; set; }
        public int SocialMediaId { get; set; }

        public PaidSocial PaidSocial { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}
