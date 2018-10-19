using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public interface ISubmission
    {
        int Id { get;  }
        int UserId { get;  }
        int CompanyId { get;  }
         DateTime CampaignStartDate { get;  }
         int CampaignDuration { get;  }
         decimal TotalBudget { get;  }
         int Tier1Objective { get;  }
         int PreferredMediaApproach { get;  }
         int TierId { get;  }
         int Tier2ObjectiveId { get;  }
         bool IsBudgetFlexible { get;  }
         bool IsCampaignContinuous { get;  }
         bool IsCustomMarketSchedule { get;  }
         bool IsCustomMarketBudget { get;  }
         string Remarks { get;  }
         string Tier2ObjectiveGoal { get;  }
         string Tier2ObjectiveBudgetFlexibility { get;  }
         int? CampaignDurationTypeId { get;  }
         string AuthorizationName { get;  }
         bool? IsAuthorized { get;  }
    }
    public partial class Submission : ISubmission
    {
        public Submission()
        {
            Audience = new HashSet<Audience>();
            Budget = new HashSet<Budget>();
            DigitalDisplay = new HashSet<DigitalDisplay>();
            LocalRadio = new HashSet<LocalRadio>();
            LocalTv = new HashSet<LocalTv>();
            MarketCalendarOverride = new HashSet<MarketCalendarOverride>();
            MixHistory = new HashSet<MixHistory>();
            NationalRadio = new HashSet<NationalRadio>();
            NationalTv = new HashSet<NationalTv>();
            OnlineRadio = new HashSet<OnlineRadio>();
            OnlineVideo = new HashSet<OnlineVideo>();
            OutOfHome = new HashSet<OutOfHome>();
            PaidSearch = new HashSet<PaidSearch>();
            PaidSocial = new HashSet<PaidSocial>();
            PrintMedia = new HashSet<PrintMedia>();
            SubmissionDma = new HashSet<SubmissionDma>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public DateTime CampaignStartDate { get; set; }
        public int CampaignDuration { get; set; }
        public decimal TotalBudget { get; set; }
        public int Tier1Objective { get; set; }
        public int PreferredMediaApproach { get; set; }
        public int TierId { get; set; }
        public int Tier2ObjectiveId { get; set; }
        public bool IsBudgetFlexible { get; set; }
        public bool IsCampaignContinuous { get; set; }
        public bool IsCustomMarketSchedule { get; set; }
        public bool IsCustomMarketBudget { get; set; }
        public string Remarks { get; set; }
        public string Tier2ObjectiveGoal { get; set; }
        public string Tier2ObjectiveBudgetFlexibility { get; set; }
        public int? CampaignDurationTypeId { get; set; }
        public string AuthorizationName { get; set; }
        public bool? IsAuthorized { get; set; }

        public CampaignDurationType CampaignDurationType { get; set; }
        public CompanyInfo Company { get; set; }
        public Tier Tier { get; set; }
        public Tier2Objective Tier2Objective { get; set; }
        public User User { get; set; }
        public ICollection<Audience> Audience { get; set; }
        public ICollection<Budget> Budget { get; set; }
        public ICollection<DigitalDisplay> DigitalDisplay { get; set; }
        public ICollection<LocalRadio> LocalRadio { get; set; }
        public ICollection<LocalTv> LocalTv { get; set; }
        public ICollection<MarketCalendarOverride> MarketCalendarOverride { get; set; }
        public ICollection<MixHistory> MixHistory { get; set; }
        public ICollection<NationalRadio> NationalRadio { get; set; }
        public ICollection<NationalTv> NationalTv { get; set; }
        public ICollection<OnlineRadio> OnlineRadio { get; set; }
        public ICollection<OnlineVideo> OnlineVideo { get; set; }
        public ICollection<OutOfHome> OutOfHome { get; set; }
        public ICollection<PaidSearch> PaidSearch { get; set; }
        public ICollection<PaidSocial> PaidSocial { get; set; }
        public ICollection<PrintMedia> PrintMedia { get; set; }
        public ICollection<SubmissionDma> SubmissionDma { get; set; }
    }
}
