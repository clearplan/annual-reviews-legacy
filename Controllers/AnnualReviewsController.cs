using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CP.AnnualReviews.Models;
using CP.AnnualReviews.ViewModels;

namespace CP.AnnualReviews.Controllers
{
    public class AnnualReviewsController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewsController(ReviewContext context)
        {
            this._context = context;
        }

        // GET: AnnualReviews
        public async Task<IActionResult> Index()
        {
            var data = await _context.TblAnnualReviews.ToListAsync();
            return View(data);
        }

        // GET: /annualreviews/list
        public async Task<IActionResult> List()
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

        // GET: /annualreviews/users 
        // displays a condensed list of annual reviews for all users.
        public async Task<IActionResult> Users()
        {
            var reviews = await _context.TblAnnualReviews.ToListAsync();
            return View(reviews);
        }

        // GET: /annualreviews/users/{id} 
        [Route("/annualreviews/users/review/{id}")]
        public IActionResult UserReview(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(List));
            }

            // this sucks
            var query = (from review in _context.TblAnnualReviews
                         join resource in _context.TblResources on review.ResourceId equals resource.ResourceId into r
                         from resource in r.DefaultIfEmpty()
                         join comment in _context.TblAnnualReviewsManagementComments on review.Id equals comment.AnnualReviewId into c
                         from comment in c.DefaultIfEmpty()
                         where review.Id == id
                         select new AnnualReviewModel
                         {
                             Email = resource.Email,
                             FullName = resource.FullName,
                             ReviewDate = review.ReviewDate,
                             Comments = comment.Comments,
                             CommentsBy = comment.CommentsBy,
                             CommentsDate = comment.CommentsDate,
                             Questions = (from question in _context.TblAnnualReviewGeneralQuestions
                                          join response in _context.TblAnnualReviewGeneralQuestionResponses on question.Id equals response.GeneralQuestionId
                                          where response.AnnualReviewId == id
                                          select new TblAnnualReviewGeneralQuestion
                                          { 
                                              QuestionNumber = question.QuestionNumber,
                                              QuestionText = question.QuestionText,
                                              Response = response.GeneralQuestionResponse
                                          }).ToList(),
                             Competencies = (from c in _context.TblAnnualReviewCompetencies
                                             join r in _context.TblAnnualReviewCompetencyResponses on c.CompetencyNumber equals r.CompetencyNumber
                                             where r.AnnualReviewId == id
                                             select new TblAnnualReviewCompetency
                                             { 
                                                CompetencyNumber = c.CompetencyNumber,
                                                CompetencyText = c.CompetencyText,
                                                CompetencyDescription = c.CompetencyDescription,
                                                ExperienceAndCapabilityRatingId = r.CompetencyResponseExperienceCapabilityRatingId,
                                                Industries = r.CompetencyResponseIndustry,
                                                Notes = r.CompetencyResponseNotes,
                                                GrowthInterest = r.CompetencyResponseGrowthInterest
                                             }).ToList(),
                             ToolsoftheTrade = (from t in _context.TblAnnualReviewToolsoftheTradeCategories
                                                join r in _context.TblAnnualReviewToolsoftheTradeResponses on t.Id equals r.ToolsoftheTradeId
                                                //join tt in _context.TblAnnualReviewToolsoftheTrades on r.ToolsoftheTradeId equals tt.ToolCategoryId into trade
                                                //from tt in trade.DefaultIfEmpty()
                                                where r.AnnualReviewId == id
                                                select new TblAnnualReviewToolsoftheTradeCategory
                                                { 
                                                    ToolCategoryName = t.ToolCategoryName,
                                                    ToolRating = r.ToolsoftheTradeRating
                                                })
                                                .ToList()
                         })
                         .FirstOrDefault();

            if (query == null)
            {
                return NotFound();
            }

            return View(query);
        }


        // GET: AnnualReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReview = await _context.TblAnnualReviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReview == null)
            {
                return NotFound();
            }

            return View(tblAnnualReview);
        }

        // GET: AnnualReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResourceId,ReviewDate,ReviewerId,ReviewStatusId,ReviewName")] TblAnnualReview tblAnnualReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReview);
        }

        // GET: AnnualReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReview = await _context.TblAnnualReviews.FindAsync(id);
            if (tblAnnualReview == null)
            {
                return NotFound();
            }
            return View(tblAnnualReview);
        }

        // POST: AnnualReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResourceId,ReviewDate,ReviewerId,ReviewStatusId,ReviewName")] TblAnnualReview tblAnnualReview)
        {
            if (id != tblAnnualReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewExists(tblAnnualReview.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReview);
        }

        // GET: AnnualReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReview = await _context.TblAnnualReviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReview == null)
            {
                return NotFound();
            }

            return View(tblAnnualReview);
        }

        // POST: AnnualReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReview = await _context.TblAnnualReviews.FindAsync(id);
            _context.TblAnnualReviews.Remove(tblAnnualReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewExists(int id)
        {
            return _context.TblAnnualReviews.Any(e => e.Id == id);
        }
    }
}
