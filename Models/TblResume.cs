using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Resumes")]
    public partial class TblResume
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ResourceID")]
        public int ResourceId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string Overview { get; set; }
        [Column("ResumeStatusID")]
        public int? ResumeStatusId { get; set; }
        [StringLength(50)]
        public string ResumeName { get; set; }
        public int? ReviewedByManager { get; set; }
    }
}
