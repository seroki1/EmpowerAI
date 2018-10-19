using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmpowerAI.Models
{
    public partial class EmpowerAIContext : DbContext
    {
        public EmpowerAIContext()
        {
        }

        public EmpowerAIContext(DbContextOptions<EmpowerAIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audience> Audience { get; set; }
        public virtual DbSet<AudienceDemographic> AudienceDemographic { get; set; }
        public virtual DbSet<BannerSize> BannerSize { get; set; }
        public virtual DbSet<Budget> Budget { get; set; }
        public virtual DbSet<CampaignDurationType> CampaignDurationType { get; set; }
        public virtual DbSet<ChannelPreference> ChannelPreference { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<Demographic> Demographic { get; set; }
        public virtual DbSet<DigitalDisplay> DigitalDisplay { get; set; }
        public virtual DbSet<DigitalDisplayBannerSize> DigitalDisplayBannerSize { get; set; }
        public virtual DbSet<Dma> Dma { get; set; }
        public virtual DbSet<LocalRadio> LocalRadio { get; set; }
        public virtual DbSet<LocalRadioRadioDaypart> LocalRadioRadioDaypart { get; set; }
        public virtual DbSet<LocalTv> LocalTv { get; set; }
        public virtual DbSet<LocalTvSpotLength> LocalTvSpotLength { get; set; }
        public virtual DbSet<LocalTvTvdaypart> LocalTvTvdaypart { get; set; }
        public virtual DbSet<MarketCalendarOverride> MarketCalendarOverride { get; set; }
        public virtual DbSet<MarketCalendarOverrideWeek> MarketCalendarOverrideWeek { get; set; }
        public virtual DbSet<MixHistory> MixHistory { get; set; }
        public virtual DbSet<NationalRadio> NationalRadio { get; set; }
        public virtual DbSet<NationalRadioRadioDaypart> NationalRadioRadioDaypart { get; set; }
        public virtual DbSet<NationalTv> NationalTv { get; set; }
        public virtual DbSet<NationalTvSpotLength> NationalTvSpotLength { get; set; }
        public virtual DbSet<NationalTvTvdaypart> NationalTvTvdaypart { get; set; }
        public virtual DbSet<OnlineRadio> OnlineRadio { get; set; }
        public virtual DbSet<OnlineVideo> OnlineVideo { get; set; }
        public virtual DbSet<OutOfHome> OutOfHome { get; set; }
        public virtual DbSet<PaidSearch> PaidSearch { get; set; }
        public virtual DbSet<PaidSearchSearchEngine> PaidSearchSearchEngine { get; set; }
        public virtual DbSet<PaidSocial> PaidSocial { get; set; }
        public virtual DbSet<PaidSocialSocialMedia> PaidSocialSocialMedia { get; set; }
        public virtual DbSet<PrintMedia> PrintMedia { get; set; }
        public virtual DbSet<RadioDaypart> RadioDaypart { get; set; }
        public virtual DbSet<SearchEngine> SearchEngine { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<SpotLength> SpotLength { get; set; }
        public virtual DbSet<Submission> Submission { get; set; }
        public virtual DbSet<SubmissionDma> SubmissionDma { get; set; }
        public virtual DbSet<Tier> Tier { get; set; }
        public virtual DbSet<Tier2Objective> Tier2Objective { get; set; }
        public virtual DbSet<Tvdaypart> Tvdaypart { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SHOUPVM\\SQLEXPRESS02;Initial Catalog=EmpowerAI;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audience>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.Audience)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audiences_NewSubmission");
            });

            modelBuilder.Entity<AudienceDemographic>(entity =>
            {
                entity.ToTable("Audience_Demographic");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AudienceId).HasColumnName("AudienceID");

                entity.Property(e => e.DemographicId).HasColumnName("DemographicID");

                entity.HasOne(d => d.Audience)
                    .WithMany(p => p.AudienceDemographic)
                    .HasForeignKey(d => d.AudienceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audiences_Demographics_Audiences");

                entity.HasOne(d => d.Demographic)
                    .WithMany(p => p.AudienceDemographic)
                    .HasForeignKey(d => d.DemographicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Audiences_Demographics_TraditionalDemographics");
            });

            modelBuilder.Entity<BannerSize>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BannerSize1)
                    .IsRequired()
                    .HasColumnName("BannerSize")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dmaid).HasColumnName("DMAID");

                entity.Property(e => e.DollarValue).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.Dma)
                    .WithMany(p => p.Budget)
                    .HasForeignKey(d => d.Dmaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Budget_DMA");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.Budget)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Budget_Submission");
            });

            modelBuilder.Entity<CampaignDurationType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChannelPreference>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChannelPreference1)
                    .IsRequired()
                    .HasColumnName("ChannelPreference")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyInfo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BillAddress).IsRequired();

                entity.Property(e => e.BillAddress2).IsRequired();

                entity.Property(e => e.BillCity).IsRequired();

                entity.Property(e => e.BillState).IsRequired();

                entity.Property(e => e.BillZip)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName).IsRequired();

                entity.Property(e => e.Contact).IsRequired();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Demographic>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Demographic1)
                    .IsRequired()
                    .HasColumnName("Demographic")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DigitalDisplay>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.DigitalDisplay)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DigitalDisplayNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.DigitalDisplay)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DigitalDisplayNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<DigitalDisplayBannerSize>(entity =>
            {
                entity.ToTable("DigitalDisplay_BannerSize");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BannerSizeId).HasColumnName("BannerSizeID");

                entity.Property(e => e.DigitalDisplayId).HasColumnName("DigitalDisplayID");

                entity.HasOne(d => d.BannerSize)
                    .WithMany(p => p.DigitalDisplayBannerSize)
                    .HasForeignKey(d => d.BannerSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DigitalDisplay_Banner_BannerSize");

                entity.HasOne(d => d.DigitalDisplay)
                    .WithMany(p => p.DigitalDisplayBannerSize)
                    .HasForeignKey(d => d.DigitalDisplayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DigitalDisplay_Banner_DigitalDisplayNewSubmission");
            });

            modelBuilder.Entity<Dma>(entity =>
            {
                entity.ToTable("DMA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dmaname)
                    .IsRequired()
                    .HasColumnName("DMAName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocalRadio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.LocalRadio)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalRadioNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.LocalRadio)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalRadioNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<LocalRadioRadioDaypart>(entity =>
            {
                entity.ToTable("LocalRadio_RadioDaypart");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LocalRadioId).HasColumnName("LocalRadioID");

                entity.Property(e => e.RadioDaypartId).HasColumnName("RadioDaypartID");

                entity.HasOne(d => d.LocalRadio)
                    .WithMany(p => p.LocalRadioRadioDaypart)
                    .HasForeignKey(d => d.LocalRadioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalRadio_RadioDaypart_LocalRadio");

                entity.HasOne(d => d.RadioDaypart)
                    .WithMany(p => p.LocalRadioRadioDaypart)
                    .HasForeignKey(d => d.RadioDaypartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalRadio_RadioDaypart_RadioDaypart");
            });

            modelBuilder.Entity<LocalTv>(entity =>
            {
                entity.ToTable("LocalTV");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.LocalTv)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalTVNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.LocalTv)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalTVNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<LocalTvSpotLength>(entity =>
            {
                entity.ToTable("LocalTV_SpotLength");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LocalTvid).HasColumnName("LocalTVID");

                entity.Property(e => e.SpotLengthId).HasColumnName("SpotLengthID");

                entity.HasOne(d => d.LocalTv)
                    .WithMany(p => p.LocalTvSpotLength)
                    .HasForeignKey(d => d.LocalTvid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalTV_SpotLength_LocalTVNewSubmission");

                entity.HasOne(d => d.SpotLength)
                    .WithMany(p => p.LocalTvSpotLength)
                    .HasForeignKey(d => d.SpotLengthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalTV_SpotLength_SpotLength");
            });

            modelBuilder.Entity<LocalTvTvdaypart>(entity =>
            {
                entity.ToTable("LocalTV_TVDaypart");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LocalTvid).HasColumnName("LocalTVID");

                entity.Property(e => e.TvdaypartId).HasColumnName("TVDaypartID");

                entity.HasOne(d => d.LocalTv)
                    .WithMany(p => p.LocalTvTvdaypart)
                    .HasForeignKey(d => d.LocalTvid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalTV_Daypart_LocalTVNewSubmission");

                entity.HasOne(d => d.Tvdaypart)
                    .WithMany(p => p.LocalTvTvdaypart)
                    .HasForeignKey(d => d.TvdaypartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalTV_Daypart_Dayparts");
            });

            modelBuilder.Entity<MarketCalendarOverride>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dmaid).HasColumnName("DMAID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.Dma)
                    .WithMany(p => p.MarketCalendarOverride)
                    .HasForeignKey(d => d.Dmaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketCalendarOverride_DMA");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.MarketCalendarOverride)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketCalendarOverride_Submission");
            });

            modelBuilder.Entity<MarketCalendarOverrideWeek>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MarketCalendarOverrideId).HasColumnName("MarketCalendarOverrideID");

                entity.Property(e => e.WeekOf).HasColumnType("date");

                entity.HasOne(d => d.MarketCalendarOverride)
                    .WithMany(p => p.MarketCalendarOverrideWeek)
                    .HasForeignKey(d => d.MarketCalendarOverrideId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calendar_MarketCalendar");
            });

            modelBuilder.Entity<MixHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FileLocation).IsRequired();

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.MixHistory)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MixHistory_NewSubmission");
            });

            modelBuilder.Entity<NationalRadio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.NationalRadio)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalRadioNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.NationalRadio)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalRadioNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<NationalRadioRadioDaypart>(entity =>
            {
                entity.ToTable("NationalRadio_RadioDaypart");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NationalRadioId).HasColumnName("NationalRadioID");

                entity.Property(e => e.RadioDaypartId).HasColumnName("RadioDaypartID");

                entity.HasOne(d => d.NationalRadio)
                    .WithMany(p => p.NationalRadioRadioDaypart)
                    .HasForeignKey(d => d.NationalRadioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalRadio_RadioDaypart_NationalRadio");

                entity.HasOne(d => d.RadioDaypart)
                    .WithMany(p => p.NationalRadioRadioDaypart)
                    .HasForeignKey(d => d.RadioDaypartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalRadio_RadioDaypart_RadioDaypart");
            });

            modelBuilder.Entity<NationalTv>(entity =>
            {
                entity.ToTable("NationalTV");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.NationalTv)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalTVNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.NationalTv)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalTVNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<NationalTvSpotLength>(entity =>
            {
                entity.ToTable("NationalTV_SpotLength");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NationalTvid).HasColumnName("NationalTVID");

                entity.Property(e => e.SpotLengthId).HasColumnName("SpotLengthID");

                entity.HasOne(d => d.NationalTv)
                    .WithMany(p => p.NationalTvSpotLength)
                    .HasForeignKey(d => d.NationalTvid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalTV_SpotLength_NationalTVNewSubmission");

                entity.HasOne(d => d.SpotLength)
                    .WithMany(p => p.NationalTvSpotLength)
                    .HasForeignKey(d => d.SpotLengthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalTV_SpotLength_SpotLength");
            });

            modelBuilder.Entity<NationalTvTvdaypart>(entity =>
            {
                entity.ToTable("NationalTV_TVDaypart");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NationalTvid).HasColumnName("NationalTVID");

                entity.Property(e => e.TvdaypartId).HasColumnName("TVDaypartID");

                entity.HasOne(d => d.NationalTv)
                    .WithMany(p => p.NationalTvTvdaypart)
                    .HasForeignKey(d => d.NationalTvid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalTV_Daypart_NationalTVNewSubmission");

                entity.HasOne(d => d.Tvdaypart)
                    .WithMany(p => p.NationalTvTvdaypart)
                    .HasForeignKey(d => d.TvdaypartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NationalTV_Daypart_TVDaypart");
            });

            modelBuilder.Entity<OnlineRadio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.OnlineRadio)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineRadioNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.OnlineRadio)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineRadioNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<OnlineVideo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.OnlineVideo)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineVideoNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.OnlineVideo)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineVideoNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<OutOfHome>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.OutOfHome)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutOfHomeNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.OutOfHome)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutOfHomeNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<PaidSearch>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.PaidSearch)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaidSearchNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.PaidSearch)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaidSearchNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<PaidSearchSearchEngine>(entity =>
            {
                entity.ToTable("PaidSearch_SearchEngine");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PaidSearchId).HasColumnName("PaidSearchID");

                entity.Property(e => e.SearchEngineId).HasColumnName("SearchEngineID");

                entity.HasOne(d => d.PaidSearch)
                    .WithMany(p => p.PaidSearchSearchEngine)
                    .HasForeignKey(d => d.PaidSearchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaidSearch_SearchEngine_PaidSearchNewSubmission");

                entity.HasOne(d => d.SearchEngine)
                    .WithMany(p => p.PaidSearchSearchEngine)
                    .HasForeignKey(d => d.SearchEngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaidSearch_SearchEngine_SearchEngine");
            });

            modelBuilder.Entity<PaidSocial>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.PaidSocial)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaidSocialNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.PaidSocial)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaidSocialNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<PaidSocialSocialMedia>(entity =>
            {
                entity.ToTable("PaidSocial_SocialMedia");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PaidSocialId).HasColumnName("PaidSocialID");

                entity.Property(e => e.SocialMediaId).HasColumnName("SocialMediaID");

                entity.HasOne(d => d.PaidSocial)
                    .WithMany(p => p.PaidSocialSocialMedia)
                    .HasForeignKey(d => d.PaidSocialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaidSocial_SocialMedia_PaidSocialNewSubmission");

                entity.HasOne(d => d.SocialMedia)
                    .WithMany(p => p.PaidSocialSocialMedia)
                    .HasForeignKey(d => d.SocialMediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaidSocial_SocialMedia_SocialMedia");
            });

            modelBuilder.Entity<PrintMedia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BudgetPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChannelPreferenceId).HasColumnName("ChannelPreferenceID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.ChannelPreference)
                    .WithMany(p => p.PrintMedia)
                    .HasForeignKey(d => d.ChannelPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrintMediaNewSubmission_ChannelPreference");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.PrintMedia)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrintMediaNewSubmission_NewSubmission");
            });

            modelBuilder.Entity<RadioDaypart>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Daypart)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SearchEngine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SearchEngineName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SocialMediaName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpotLength>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SpotLength1)
                    .HasColumnName("SpotLength")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorizationName).HasMaxLength(250);

                entity.Property(e => e.CampaignDuration).HasDefaultValueSql("((13))");

                entity.Property(e => e.CampaignDurationTypeId).HasColumnName("CampaignDurationTypeID");

                entity.Property(e => e.CampaignStartDate).HasColumnType("date");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Tier2ObjectiveId).HasColumnName("Tier2ObjectiveID");

                entity.Property(e => e.TierId).HasColumnName("TierID");

                entity.Property(e => e.TotalBudget).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CampaignDurationType)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.CampaignDurationTypeId)
                    .HasConstraintName("FK_Submission_CampaignDurationType");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewSubmission_CompanyInfo");

                entity.HasOne(d => d.Tier2Objective)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.Tier2ObjectiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Submission_Tier2Objective");

                entity.HasOne(d => d.Tier)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.TierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Submission_Tier");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewSubmission_User");
            });

            modelBuilder.Entity<SubmissionDma>(entity =>
            {
                entity.ToTable("Submission_DMA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dmaid).HasColumnName("DMAID");

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.Dma)
                    .WithMany(p => p.SubmissionDma)
                    .HasForeignKey(d => d.Dmaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Submission_DMA_DMA");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.SubmissionDma)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Submission_DMA_Submission");
            });

            modelBuilder.Entity<Tier>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TierName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tier2Objective>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Objective)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tvdaypart>(entity =>
            {
                entity.ToTable("TVDaypart");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Daypart)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LockoutEndDate).HasColumnType("date");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_CompanyInfo");
            });
        }
    }
}
