using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Tasks")]
    public partial class TblTask
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string AssignedTo { get; set; }
        [StringLength(256)]
        public string TaskName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }
        [Column("TaskStatusID")]
        public int? TaskStatusId { get; set; }
        [Column("TaskTypeID")]
        public int? TaskTypeId { get; set; }
        [Column("AssociatedRecordID")]
        public int? AssociatedRecordId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Archived { get; set; }
    }
}
