using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP.AnnualReviews.Models;

namespace CP.AnnualReviews.ViewModels
{
    public class AnnualReviewModel
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int? ReviewerId { get; set; }
        public int? ReviewStatusId { get; set; }
        public string ReviewName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string Suffix { get; set; }
        public int? DepartmentId { get; set; }
        public byte[] Image { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int StatusId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ReportsToId { get; set; }
        public int? RoleId { get; set; }
        public int AnnualReviewId { get; set; }
        public string Comments { get; set; }
        public string CommentsBy { get; set; }
        public DateTime? CommentsDate { get; set; }
        public IEnumerable<TblAnnualReviewGeneralQuestion> Questions { get; set; }
        public IEnumerable<TblAnnualReviewCompetency> Competencies { get; set; }
        public IEnumerable<TblAnnualReviewToolsoftheTradeCategory> ToolsoftheTrade { get; set; }
    }
}
