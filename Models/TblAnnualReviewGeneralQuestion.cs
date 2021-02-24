using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReview_GeneralQuestions")]
    public partial class TblAnnualReviewGeneralQuestion
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int QuestionNumber { get; set; }
        [Required]
        [StringLength(256)]
        public string QuestionText { get; set; }

        [NotMapped]
        public string Response { get; set; }
    }
}
