﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReview_Industry_Responses")]
    public partial class TblAnnualReviewIndustryResponse
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("AnnualReviewID")]
        public int AnnualReviewId { get; set; }
        [Column("CompetencyResponseID")]
        public int CompetencyResponseId { get; set; }
        [Column("IndustryID")]
        public int IndustryId { get; set; }
    }
}
