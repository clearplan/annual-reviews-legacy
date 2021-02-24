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
    public class AnnualReviewCompetencyResponsesController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewCompetencyResponsesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: AnnualReviewCompetencyResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewCompetencyResponses.ToListAsync());
        }

        // GET: AnnualReviewCompetencyResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewCompetencyResponse = await _context.TblAnnualReviewCompetencyResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewCompetencyResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewCompetencyResponse);
        }

        // GET: AnnualReviewCompetencyResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviewCompetencyResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnnualReviewId,CompetencyNumber,CompetencyResponseExperienceCapabilityRatingId,CompetencyResponseIndustry,CompetencyResponseGrowthInterest,CompetencyResponseNotes")] TblAnnualReviewCompetencyResponse tblAnnualReviewCompetencyResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewCompetencyResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewCompetencyResponse);
        }

        // GET: AnnualReviewCompetencyResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewCompetencyResponse = await _context.TblAnnualReviewCompetencyResponses.FindAsync(id);
            if (tblAnnualReviewCompetencyResponse == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewCompetencyResponse);
        }

        // POST: AnnualReviewCompetencyResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnnualReviewId,CompetencyNumber,CompetencyResponseExperienceCapabilityRatingId,CompetencyResponseIndustry,CompetencyResponseGrowthInterest,CompetencyResponseNotes")] TblAnnualReviewCompetencyResponse tblAnnualReviewCompetencyResponse)
        {
            if (id != tblAnnualReviewCompetencyResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewCompetencyResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewCompetencyResponseExists(tblAnnualReviewCompetencyResponse.Id))
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
            return View(tblAnnualReviewCompetencyResponse);
        }

        // GET: AnnualReviewCompetencyResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewCompetencyResponse = await _context.TblAnnualReviewCompetencyResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewCompetencyResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewCompetencyResponse);
        }

        // POST: AnnualReviewCompetencyResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewCompetencyResponse = await _context.TblAnnualReviewCompetencyResponses.FindAsync(id);
            _context.TblAnnualReviewCompetencyResponses.Remove(tblAnnualReviewCompetencyResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewCompetencyResponseExists(int id)
        {
            return _context.TblAnnualReviewCompetencyResponses.Any(e => e.Id == id);
        }
    }
}
