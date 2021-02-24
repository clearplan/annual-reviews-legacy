using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReviews_Management_Comments")]
    public partial class TblAnnualReviewsManagementComment
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("AnnualReviewID")]
        public int AnnualReviewId { get; set; }
        public string Comments { get; set; }
        public string CommentsBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CommentsDate { get; set; }
    }
}
