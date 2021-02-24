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
    public class AnnualReviewsProgramPhasesController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewsProgramPhasesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: AnnualReviewsProgramPhases
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewProgramPhases.ToListAsync());
        }

        // GET: AnnualReviewsProgramPhases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewProgramPhase = await _context.TblAnnualReviewProgramPhases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewProgramPhase == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewProgramPhase);
        }

        // GET: AnnualReviewsProgramPhases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviewsProgramPhases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProgramPhase")] TblAnnualReviewProgramPhase tblAnnualReviewProgramPhase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewProgramPhase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewProgramPhase);
        }

        // GET: AnnualReviewsProgramPhases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewProgramPhase = await _context.TblAnnualReviewProgramPhases.FindAsync(id);
            if (tblAnnualReviewProgramPhase == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewProgramPhase);
        }

        // POST: AnnualReviewsProgramPhases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProgramPhase")] TblAnnualReviewProgramPhase tblAnnualReviewProgramPhase)
        {
            if (id != tblAnnualReviewProgramPhase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewProgramPhase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewProgramPhaseExists(tblAnnualReviewProgramPhase.Id))
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
            return View(tblAnnualReviewProgramPhase);
        }

        // GET: AnnualReviewsProgramPhases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewProgramPhase = await _context.TblAnnualReviewProgramPhases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewProgramPhase == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewProgramPhase);
        }

        // POST: AnnualReviewsProgramPhases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewProgramPhase = await _context.TblAnnualReviewProgramPhases.FindAsync(id);
            _context.TblAnnualReviewProgramPhases.Remove(tblAnnualReviewProgramPhase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewProgramPhaseExists(int id)
        {
            return _context.TblAnnualReviewProgramPhases.Any(e => e.Id == id);
        }
    }
}
