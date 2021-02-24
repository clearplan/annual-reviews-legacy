using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReview_Competency_Responses")]
    public partial class TblAnnualReviewCompetencyResponse
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("AnnualReviewID")]
        public int AnnualReviewId { get; set; }
        public int CompetencyNumber { get; set; }
        [Column("CompetencyResponse_ExperienceCapabilityRatingID")]
        public int? CompetencyResponseExperienceCapabilityRatingId { get; set; }
        [Column("CompetencyResponse_Industry")]
        [StringLength(256)]
        public string CompetencyResponseIndustry { get; set; }
        [Column("CompetencyResponse_GrowthInterest")]
        public bool? CompetencyResponseGrowthInterest { get; set; }
        [Column("CompetencyResponse_Notes")]
        public string CompetencyResponseNotes { get; set; }
    }
}
