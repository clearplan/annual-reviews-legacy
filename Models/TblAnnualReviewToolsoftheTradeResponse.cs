using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReview_ToolsoftheTrade_Responses")]
    public partial class TblAnnualReviewToolsoftheTradeResponse
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("AnnualReviewID")]
        public int AnnualReviewId { get; set; }
        [Column("ToolsoftheTradeID")]
        public int ToolsoftheTradeId { get; set; }
        public int ToolsoftheTradeRating { get; set; }
    }
}
