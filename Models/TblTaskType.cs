﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_TaskType")]
    public partial class TblTaskType
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TaskType { get; set; }
    }
}
