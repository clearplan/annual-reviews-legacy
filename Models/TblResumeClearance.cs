using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Resume_Clearances")]
    public partial class TblResumeClearance
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ResumeID")]
        public int ResumeId { get; set; }
        [StringLength(256)]
        public string Clearance { get; set; }
        [StringLength(256)]
        public string IssuedBy { get; set; }
        [StringLength(256)]
        public string InvestigationType { get; set; }
        [StringLength(256)]
        public string ProgramAccess { get; set; }
        [StringLength(256)]
        public string AdditionalInvestigations { get; set; }
    }
}
