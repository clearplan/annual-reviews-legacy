using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_ResumeFiles")]
    public partial class TblResumeFile
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
        [StringLength(256)]
        public string FileName { get; set; }
        public string FilePath { get; set; }
        [Column("ResumeID")]
        public int? ResumeId { get; set; }
    }
}
