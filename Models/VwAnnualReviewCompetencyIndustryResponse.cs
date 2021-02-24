using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Keyless]
    public partial class VwAnnualReviewCompetencyIndustryResponse
    {
        [Column("AnnualReviewID")]
        public int AnnualReviewId { get; set; }
        [Column("CompetencyResponseID")]
        public int CompetencyResponseId { get; set; }
        [Required]
        [StringLength(256)]
        public string Industry { get; set; }
    }
}
