﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_Industries")]
    public partial class TblIndustry
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Industry { get; set; }
    }
}
