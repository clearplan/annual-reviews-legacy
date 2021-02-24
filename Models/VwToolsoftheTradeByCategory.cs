using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Keyless]
    public partial class VwToolsoftheTradeByCategory
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string ToolCategoryName { get; set; }
        [Column("ToolCategoryID")]
        public int ToolCategoryId { get; set; }
        [Required]
        [StringLength(256)]
        public string ToolName { get; set; }
        [Column("ToolID")]
        public int ToolId { get; set; }
    }
}
