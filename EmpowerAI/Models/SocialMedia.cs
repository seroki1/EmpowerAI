using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class SocialMedia
    {
        public SocialMedia()
        {
            PaidSocialSocialMedia = new HashSet<PaidSocialSocialMedia>();
        }

        public int Id { get; set; }
        public string SocialMediaName { get; set; }

        public ICollection<PaidSocialSocialMedia> PaidSocialSocialMedia { get; set; }
    }
}
