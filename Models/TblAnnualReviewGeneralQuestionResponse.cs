using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReview_GeneralQuestion_Responses")]
    public partial class TblAnnualReviewGeneralQuestionResponse
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("AnnualReviewID")]
        public int AnnualReviewId { get; set; }
        [Column("GeneralQuestionID")]
        public int GeneralQuestionId { get; set; }
        public string GeneralQuestionResponse { get; set; }
    }
}
