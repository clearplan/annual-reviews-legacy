using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Resume_RelevantTools")]
    public partial class TblResumeRelevantTool
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ResumeID")]
        public int ResumeId { get; set; }
        [Column("ToolsoftheTradeID")]
        public int ToolsoftheTradeId { get; set; }
    }
}
