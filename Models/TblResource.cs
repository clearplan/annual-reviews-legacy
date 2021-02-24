using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Resources")]
    public partial class TblResource
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ResourceID")]
        public int ResourceId { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string FullName { get; set; }
        [StringLength(5)]
        public string Suffix { get; set; }
        [Column("DepartmentID")]
        public int? DepartmentId { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public string Email { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [Column("StatusID")]
        public int StatusId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Column("ReportsToID")]
        public int? ReportsToId { get; set; }
        [Column("RoleID")]
        public int? RoleId { get; set; }
    }
}
