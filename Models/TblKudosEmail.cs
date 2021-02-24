using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CP.AnnualReviews.Models
{
    [Table("tbl_KudosEmails")]
    public partial class TblKudosEmail
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        [Column("CC")]
        public string Cc { get; set; }
        public string Body { get; set; }
        [StringLength(50)]
        public string DateTimeReceived { get; set; }
        public string AttachmentFileName { get; set; }
        public bool? Archived { get; set; }
    }
}
