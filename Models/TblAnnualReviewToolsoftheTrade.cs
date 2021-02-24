using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReview_ToolsoftheTrade")]
    public partial class TblAnnualReviewToolsoftheTrade
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ToolCategoryID")]
        public int ToolCategoryId { get; set; }
        [Required]
        [StringLength(256)]
        public string ToolName { get; set; }
    }
}
