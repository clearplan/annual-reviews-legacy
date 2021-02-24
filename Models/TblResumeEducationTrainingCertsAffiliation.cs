using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Resume_EducationTrainingCertsAffiliations")]
    public partial class TblResumeEducationTrainingCertsAffiliation
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ResumeID")]
        public int ResumeId { get; set; }
        [StringLength(256)]
        public string EducationTrainingCertAfilliation { get; set; }
        [StringLength(10)]
        public string Abbreviation { get; set; }
        [StringLength(256)]
        public string IssuedBy { get; set; }
    }
}
