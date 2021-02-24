using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_AnnualReviews")]
    public partial class TblAnnualReview
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ResourceID")]
        public int ResourceId { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReviewDate { get; set; }
        [Column("ReviewerID")]
        public int? ReviewerId { get; set; }
        [Column("ReviewStatusID")]
        public int? ReviewStatusId { get; set; }
        [StringLength(50)]
        public string ReviewName { get; set; }
    }
}
