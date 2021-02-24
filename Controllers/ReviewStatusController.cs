using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CP.AnnualReviews.Models;

namespace CP.AnnualReviews.Controllers
{
    public class ReviewStatusController : Controller
    {
        private readonly ReviewContext _context;

        public ReviewStatusController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ReviewStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblReviewStatuses.ToListAsync());
        }

        // GET: ReviewStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblReviewStatus = await _context.TblReviewStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblReviewStatus == null)
            {
                return NotFound();
            }

            return View(tblReviewStatus);
        }

        // GET: ReviewStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,IsDefault")] TblReviewStatus tblReviewStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblReviewStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblReviewStatus);
        }

        // GET: ReviewStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblReviewStatus = await _context.TblReviewStatuses.FindAsync(id);
            if (tblReviewStatus == null)
            {
                return NotFound();
            }
            return View(tblReviewStatus);
        }

        // POST: ReviewStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,IsDefault")] TblReviewStatus tblReviewStatus)
        {
            if (id != tblReviewStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblReviewStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblReviewStatusExists(tblReviewStatus.Id))
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
            return View(tblReviewStatus);
        }

        // GET: ReviewStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblReviewStatus = await _context.TblReviewStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblReviewStatus == null)
            {
                return NotFound();
            }

            return View(tblReviewStatus);
        }

        // POST: ReviewStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblReviewStatus = await _context.TblReviewStatuses.FindAsync(id);
            _context.TblReviewStatuses.Remove(tblReviewStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblReviewStatusExists(int id)
        {
            return _context.TblReviewStatuses.Any(e => e.Id == id);
        }
    }
}
