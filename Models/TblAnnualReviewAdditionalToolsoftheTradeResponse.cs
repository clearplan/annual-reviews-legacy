using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReview_AdditionalToolsoftheTrade_Responses")]
    public partial class TblAnnualReviewAdditionalToolsoftheTradeResponse
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("AnnualReviewID")]
        public int AnnualReviewId { get; set; }
        [Required]
        [StringLength(256)]
        public string AdditionalTooloftheTrade { get; set; }
        public int ToolsoftheTradeRating { get; set; }
    }
}
