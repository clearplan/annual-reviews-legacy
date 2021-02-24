using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CP.AnnualReviews.Models
{
    public class AnnualReviewsManagementCommentsController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewsManagementCommentsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: AnnualReviewsManagementComments
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewsManagementComments.ToListAsync());
        }

        // GET: AnnualReviewsManagementComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewsManagementComment = await _context.TblAnnualReviewsManagementComments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewsManagementComment == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewsManagementComment);
        }

        // GET: AnnualReviewsManagementComments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviewsManagementComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnnualReviewId,Comments,CommentsBy,CommentsDate")] TblAnnualReviewsManagementComment tblAnnualReviewsManagementComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewsManagementComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewsManagementComment);
        }

        // GET: AnnualReviewsManagementComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewsManagementComment = await _context.TblAnnualReviewsManagementComments.FindAsync(id);
            if (tblAnnualReviewsManagementComment == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewsManagementComment);
        }

        // POST: AnnualReviewsManagementComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnnualReviewId,Comments,CommentsBy,CommentsDate")] TblAnnualReviewsManagementComment tblAnnualReviewsManagementComment)
        {
            if (id != tblAnnualReviewsManagementComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewsManagementComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewsManagementCommentExists(tblAnnualReviewsManagementComment.Id))
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
            return View(tblAnnualReviewsManagementComment);
        }

        // GET: AnnualReviewsManagementComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewsManagementComment = await _context.TblAnnualReviewsManagementComments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewsManagementComment == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewsManagementComment);
        }

        // POST: AnnualReviewsManagementComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewsManagementComment = await _context.TblAnnualReviewsManagementComments.FindAsync(id);
            _context.TblAnnualReviewsManagementComments.Remove(tblAnnualReviewsManagementComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewsManagementCommentExists(int id)
        {
            return _context.TblAnnualReviewsManagementComments.Any(e => e.Id == id);
        }
    }
}
