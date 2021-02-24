using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Resume_AdditionalRelevantTools")]
    public partial class TblResumeAdditionalRelevantTool
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ResumeID")]
        public int ResumeId { get; set; }
        [Required]
        [StringLength(256)]
        public string AdditionalTools { get; set; }
    }
}
