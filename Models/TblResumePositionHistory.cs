using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Resume_PositionHistory")]
    public partial class TblResumePositionHistory
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ResumeID")]
        public int ResumeId { get; set; }
        [StringLength(256)]
        public string PositionTitle { get; set; }
        [StringLength(256)]
        public string DepartmentDivision { get; set; }
        [StringLength(256)]
        public string CompanyOrganizationName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public bool? PresentPosition { get; set; }
        public int? SortOrderNum { get; set; }
    }
}
