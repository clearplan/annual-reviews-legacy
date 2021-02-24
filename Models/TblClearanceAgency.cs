using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Clearance_Agencies")]
    public partial class TblClearanceAgency
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Agency { get; set; }
    }
}
