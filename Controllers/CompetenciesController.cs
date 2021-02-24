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
    public class CompetenciesController : Controller
    {
        private readonly ReviewContext _context;

        public CompetenciesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Competencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewCompetencies.ToListAsync());
        }

        // GET: Competencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewCompetency = await _context.TblAnnualReviewCompetencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewCompetency == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewCompetency);
        }

        // GET: Competencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompetencyNumber,CompetencyText,CompetencyDescription")] TblAnnualReviewCompetency tblAnnualReviewCompetency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewCompetency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewCompetency);
        }

        // GET: Competencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewCompetency = await _context.TblAnnualReviewCompetencies.FindAsync(id);
            if (tblAnnualReviewCompetency == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewCompetency);
        }

        // POST: Competencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompetencyNumber,CompetencyText,CompetencyDescription")] TblAnnualReviewCompetency tblAnnualReviewCompetency)
        {
            if (id != tblAnnualReviewCompetency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewCompetency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewCompetencyExists(tblAnnualReviewCompetency.Id))
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
            return View(tblAnnualReviewCompetency);
        }

        // GET: Competencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewCompetency = await _context.TblAnnualReviewCompetencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewCompetency == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewCompetency);
        }

        // POST: Competencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewCompetency = await _context.TblAnnualReviewCompetencies.FindAsync(id);
            _context.TblAnnualReviewCompetencies.Remove(tblAnnualReviewCompetency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewCompetencyExists(int id)
        {
            return _context.TblAnnualReviewCompetencies.Any(e => e.Id == id);
        }
    }
}
