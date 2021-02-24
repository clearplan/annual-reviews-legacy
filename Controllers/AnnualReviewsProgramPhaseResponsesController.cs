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
    public class AnnualReviewsProgramPhaseResponsesController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewsProgramPhaseResponsesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: AnnualReviewsProgramPhaseResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewProgramPhaseResponses.ToListAsync());
        }

        // GET: AnnualReviewsProgramPhaseResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewProgramPhaseResponse = await _context.TblAnnualReviewProgramPhaseResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewProgramPhaseResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewProgramPhaseResponse);
        }

        // GET: AnnualReviewsProgramPhaseResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviewsProgramPhaseResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnnualReviewId,CompetencyResponseId,ProgramPhaseId")] TblAnnualReviewProgramPhaseResponse tblAnnualReviewProgramPhaseResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewProgramPhaseResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewProgramPhaseResponse);
        }

        // GET: AnnualReviewsProgramPhaseResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewProgramPhaseResponse = await _context.TblAnnualReviewProgramPhaseResponses.FindAsync(id);
            if (tblAnnualReviewProgramPhaseResponse == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewProgramPhaseResponse);
        }

        // POST: AnnualReviewsProgramPhaseResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnnualReviewId,CompetencyResponseId,ProgramPhaseId")] TblAnnualReviewProgramPhaseResponse tblAnnualReviewProgramPhaseResponse)
        {
            if (id != tblAnnualReviewProgramPhaseResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewProgramPhaseResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewProgramPhaseResponseExists(tblAnnualReviewProgramPhaseResponse.Id))
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
            return View(tblAnnualReviewProgramPhaseResponse);
        }

        // GET: AnnualReviewsProgramPhaseResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewProgramPhaseResponse = await _context.TblAnnualReviewProgramPhaseResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewProgramPhaseResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewProgramPhaseResponse);
        }

        // POST: AnnualReviewsProgramPhaseResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewProgramPhaseResponse = await _context.TblAnnualReviewProgramPhaseResponses.FindAsync(id);
            _context.TblAnnualReviewProgramPhaseResponses.Remove(tblAnnualReviewProgramPhaseResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewProgramPhaseResponseExists(int id)
        {
            return _context.TblAnnualReviewProgramPhaseResponses.Any(e => e.Id == id);
        }
    }
}
