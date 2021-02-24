using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Resume_ProjectExperience")]
    public partial class TblResumeProjectExperience
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ResumeID")]
        public int ResumeId { get; set; }
        [StringLength(256)]
        public string ProjectTitle { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public string ProjectExperienceDetails { get; set; }
        [StringLength(256)]
        public string CompanyOrganizationName { get; set; }
        public int? SortOrderNum { get; set; }
    }
}
