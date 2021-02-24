using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Keyless]
    public partial class VwAllTasksNotCompletedSortedByDueDateAsc
    {
        [StringLength(256)]
        public string Task { get; set; }
        public string AssignedTo { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
