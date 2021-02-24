using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReview_Competencies")]
    public partial class TblAnnualReviewCompetency
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        public int CompetencyNumber { get; set; }

        [Required]
        [StringLength(256)]
        public string CompetencyText { get; set; }

        public string CompetencyDescription { get; set; }
        
        [NotMapped]
        public string Industries { get; set; }

        [NotMapped]
        public List<string> Tools { get; set; }

        [NotMapped]
        public List<string> Phases { get; set; }

        [NotMapped]
        public string Notes { get; set; }

        [NotMapped]
        public int? ExperienceAndCapabilityRatingId { get; set; }

        [NotMapped]
        public bool? GrowthInterest { get; set; }

    }
}
