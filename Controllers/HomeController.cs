using CP.AnnualReviews.Models;
using CP.AnnualReviews.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CP.AnnualReviews.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReviewContext _context;

        public HomeController(ILogger<HomeController> logger, ReviewContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reviews = await _context.TblAnnualReviews.ToListAsync();
            var resources = await _context.TblResources.ToListAsync();
            var comments = await _context.TblAnnualReviewsManagementComments.ToListAsync();
            var reviewStatuses = await _context.TblReviewStatuses.ToListAsync();

            var query = (from ar in reviews
                         join rs in resources on ar.ResourceId equals rs.ResourceId
                         join mc in comments on ar.Id equals mc.AnnualReviewId
                         join rvs in reviewStatuses on ar.ReviewStatusId equals rvs.Id
                         select new AnnualReviewModel
                         {
                             Id = ar.Id,
                             ResourceId = ar.ResourceId,
                             ReviewDate = ar.ReviewDate,
                             ReviewName = ar.ReviewName,
                             Email = rs.Email,
                             Phone = rs.Phone,
                             StartDate = rs.StartDate,
                             FirstName = rs.FirstName,
                             LastName = rs.LastName,
                             FullName = rs.FullName,
                             Comments = mc.Comments,
                             CommentsBy = mc.CommentsBy,
                             CommentsDate = mc.CommentsDate
                         }).ToList();

            return View(query);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
