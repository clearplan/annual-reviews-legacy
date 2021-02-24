using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Keyless]
    public partial class VwResumeRelevantToolsByToolName
    {
        [Column("ResumeID")]
        public int ResumeId { get; set; }
        [Required]
        [StringLength(256)]
        public string Tool { get; set; }
    }
}
