using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Kudos")]
    public partial class TblKudo
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("KudosTo_DisplayName")]
        public string KudosToDisplayName { get; set; }
        [Required]
        [Column("KudosTo_Email")]
        public string KudosToEmail { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByEmail { get; set; }
        public string Note { get; set; }
        public bool? Archived { get; set; }
    }
}
