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
    public class AnnualReviewsIndustryResponsesController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewsIndustryResponsesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: AnnualReviewsIndustryResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewIndustryResponses.ToListAsync());
        }

        // GET: AnnualReviewsIndustryResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewIndustryResponse = await _context.TblAnnualReviewIndustryResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewIndustryResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewIndustryResponse);
        }

        // GET: AnnualReviewsIndustryResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviewsIndustryResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnnualReviewId,CompetencyResponseId,IndustryId")] TblAnnualReviewIndustryResponse tblAnnualReviewIndustryResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewIndustryResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewIndustryResponse);
        }

        // GET: AnnualReviewsIndustryResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewIndustryResponse = await _context.TblAnnualReviewIndustryResponses.FindAsync(id);
            if (tblAnnualReviewIndustryResponse == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewIndustryResponse);
        }

        // POST: AnnualReviewsIndustryResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnnualReviewId,CompetencyResponseId,IndustryId")] TblAnnualReviewIndustryResponse tblAnnualReviewIndustryResponse)
        {
            if (id != tblAnnualReviewIndustryResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewIndustryResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewIndustryResponseExists(tblAnnualReviewIndustryResponse.Id))
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
            return View(tblAnnualReviewIndustryResponse);
        }

        // GET: AnnualReviewsIndustryResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewIndustryResponse = await _context.TblAnnualReviewIndustryResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewIndustryResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewIndustryResponse);
        }

        // POST: AnnualReviewsIndustryResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewIndustryResponse = await _context.TblAnnualReviewIndustryResponses.FindAsync(id);
            _context.TblAnnualReviewIndustryResponses.Remove(tblAnnualReviewIndustryResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewIndustryResponseExists(int id)
        {
            return _context.TblAnnualReviewIndustryResponses.Any(e => e.Id == id);
        }
    }
}
