using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_ExperienceCapabilityScale")]
    public partial class TblExperienceCapabilityScale
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int ScaleNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string ScaleDescription { get; set; }
    }
}
