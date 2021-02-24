using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CP.AnnualReviews.Models
{
    public partial class ReviewContext : DbContext
    {
        public ReviewContext()
        {
        }

        public ReviewContext(DbContextOptions<ReviewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAnnualReview> TblAnnualReviews { get; set; }
        public virtual DbSet<TblAnnualReviewAdditionalToolsoftheTradeResponse> TblAnnualReviewAdditionalToolsoftheTradeResponses { get; set; }
        public virtual DbSet<TblAnnualReviewCompetency> TblAnnualReviewCompetencies { get; set; }
        public virtual DbSet<TblAnnualReviewCompetencyResponse> TblAnnualReviewCompetencyResponses { get; set; }
        public virtual DbSet<TblAnnualReviewCompetencyToolsResponse> TblAnnualReviewCompetencyToolsResponses { get; set; }
        public virtual DbSet<TblAnnualReviewFile> TblAnnualReviewFiles { get; set; }
        public virtual DbSet<TblAnnualReviewGeneralQuestion> TblAnnualReviewGeneralQuestions { get; set; }
        public virtual DbSet<TblAnnualReviewGeneralQuestionResponse> TblAnnualReviewGeneralQuestionResponses { get; set; }
        public virtual DbSet<TblAnnualReviewIndustryResponse> TblAnnualReviewIndustryResponses { get; set; }
        public virtual DbSet<TblAnnualReviewProgramPhase> TblAnnualReviewProgramPhases { get; set; }
        public virtual DbSet<TblAnnualReviewProgramPhaseResponse> TblAnnualReviewProgramPhaseResponses { get; set; }
        public virtual DbSet<TblAnnualReviewToolsoftheTrade> TblAnnualReviewToolsoftheTrades { get; set; }
        public virtual DbSet<TblAnnualReviewToolsoftheTradeCategory> TblAnnualReviewToolsoftheTradeCategories { get; set; }
        public virtual DbSet<TblAnnualReviewToolsoftheTradeResponse> TblAnnualReviewToolsoftheTradeResponses { get; set; }
        public virtual DbSet<TblAnnualReviewsManagementComment> TblAnnualReviewsManagementComments { get; set; }
        public virtual DbSet<TblClearance> TblClearances { get; set; }
        public virtual DbSet<TblClearanceAdditionalInvestigation> TblClearanceAdditionalInvestigations { get; set; }
        public virtual DbSet<TblClearanceAgency> TblClearanceAgencies { get; set; }
        public virtual DbSet<TblClearanceInvestigationType> TblClearanceInvestigationTypes { get; set; }
        public virtual DbSet<TblClearanceProgramAccess> TblClearanceProgramAccesses { get; set; }
        public virtual DbSet<TblDepartment> TblDepartments { get; set; }
        public virtual DbSet<TblExperienceCapabilityScale> TblExperienceCapabilityScales { get; set; }
        public virtual DbSet<TblIndustry> TblIndustries { get; set; }
        public virtual DbSet<TblKudo> TblKudos { get; set; }
        public virtual DbSet<TblKudosEmail> TblKudosEmails { get; set; }
        public virtual DbSet<TblResource> TblResources { get; set; }
        public virtual DbSet<TblResourceRole> TblResourceRoles { get; set; }
        public virtual DbSet<TblResourceStatus> TblResourceStatuses { get; set; }
        public virtual DbSet<TblResume> TblResumes { get; set; }
        public virtual DbSet<TblResumeAdditionalRelevantTool> TblResumeAdditionalRelevantTools { get; set; }
        public virtual DbSet<TblResumeClearance> TblResumeClearances { get; set; }
        public virtual DbSet<TblResumeEducationTrainingCertsAffiliation> TblResumeEducationTrainingCertsAffiliations { get; set; }
        public virtual DbSet<TblResumeFile> TblResumeFiles { get; set; }
        public virtual DbSet<TblResumePositionHistory> TblResumePositionHistories { get; set; }
        public virtual DbSet<TblResumeProjectExperience> TblResumeProjectExperiences { get; set; }
        public virtual DbSet<TblResumeRelevantTool> TblResumeRelevantTools { get; set; }
        public virtual DbSet<TblResumeStatus> TblResumeStatuses { get; set; }
        public virtual DbSet<TblReviewStatus> TblReviewStatuses { get; set; }
        public virtual DbSet<TblTask> TblTasks { get; set; }
        public virtual DbSet<TblTaskStatus> TblTaskStatuses { get; set; }
        public virtual DbSet<TblTaskType> TblTaskTypes { get; set; }
        public virtual DbSet<VwAllTasksNotCompletedSortedByDueDateAsc> VwAllTasksNotCompletedSortedByDueDateAscs { get; set; }
        public virtual DbSet<VwAnnualReviewCompetencyIndustryResponse> VwAnnualReviewCompetencyIndustryResponses { get; set; }
        public virtual DbSet<VwAnnualReviewCompetencyToolsResponse> VwAnnualReviewCompetencyToolsResponses { get; set; }
        public virtual DbSet<VwAnnualReviewProgramPhaseResponse> VwAnnualReviewProgramPhaseResponses { get; set; }
        public virtual DbSet<VwAnnualReviewToolsoftheTradeResponse> VwAnnualReviewToolsoftheTradeResponses { get; set; }
        public virtual DbSet<VwResumeRelevantToolsByToolName> VwResumeRelevantToolsByToolNames { get; set; }
        public virtual DbSet<VwToolsoftheTradeByCategory> VwToolsoftheTradeByCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CP.AnnualReview;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblKudo>(entity =>
            {
                entity.Property(e => e.Archived).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblKudosEmail>(entity =>
            {
                entity.Property(e => e.Archived).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblResource>(entity =>
            {
                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.ResourceId).HasComputedColumnSql("([ID])", false);

                entity.Property(e => e.RoleId).HasDefaultValueSql("((2))");
            });

            modelBuilder.Entity<TblResume>(entity =>
            {
                entity.Property(e => e.ResumeStatusId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblResumePositionHistory>(entity =>
            {
                entity.Property(e => e.PresentPosition).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblTask>(entity =>
            {
                entity.Property(e => e.Archived).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<VwAllTasksNotCompletedSortedByDueDateAsc>(entity =>
            {
                entity.ToView("vw_AllTasksNotCompletedSortedByDueDateASC");
            });

            modelBuilder.Entity<VwAnnualReviewCompetencyIndustryResponse>(entity =>
            {
                entity.ToView("vw_AnnualReview_CompetencyIndustry_Responses");
            });

            modelBuilder.Entity<VwAnnualReviewCompetencyToolsResponse>(entity =>
            {
                entity.ToView("vw_AnnualReview_CompetencyTools_Responses");
            });

            modelBuilder.Entity<VwAnnualReviewProgramPhaseResponse>(entity =>
            {
                entity.ToView("vw_AnnualReview_ProgramPhase_Responses");
            });

            modelBuilder.Entity<VwAnnualReviewToolsoftheTradeResponse>(entity =>
            {
                entity.ToView("vw_AnnualReview_ToolsoftheTrade_Responses");
            });

            modelBuilder.Entity<VwResumeRelevantToolsByToolName>(entity =>
            {
                entity.ToView("vw_Resume_RelevantTools_ByToolName");
            });

            modelBuilder.Entity<VwToolsoftheTradeByCategory>(entity =>
            {
                entity.ToView("vw_ToolsoftheTradeByCategory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
