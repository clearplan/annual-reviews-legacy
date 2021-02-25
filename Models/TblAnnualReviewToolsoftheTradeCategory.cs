using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReview_ToolsoftheTradeCategories")]
    public partial class TblAnnualReviewToolsoftheTradeCategory
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string ToolCategoryName { get; set; }

        [NotMapped]
        public int ToolCategoryId { get; set; }

        [NotMapped]
        public List<Tool> Tools { get; set; }

    }
}
