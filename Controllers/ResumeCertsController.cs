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
    public class ResumeCertsController : Controller
    {
        private readonly ReviewContext _context;

        public ResumeCertsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResumeCerts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResumeEducationTrainingCertsAffiliations.ToListAsync());
        }

        // GET: ResumeCerts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeEducationTrainingCertsAffiliation = await _context.TblResumeEducationTrainingCertsAffiliations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeEducationTrainingCertsAffiliation == null)
            {
                return NotFound();
            }

            return View(tblResumeEducationTrainingCertsAffiliation);
        }

        // GET: ResumeCerts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResumeCerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResumeId,EducationTrainingCertAfilliation,Abbreviation,IssuedBy")] TblResumeEducationTrainingCertsAffiliation tblResumeEducationTrainingCertsAffiliation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResumeEducationTrainingCertsAffiliation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResumeEducationTrainingCertsAffiliation);
        }

        // GET: ResumeCerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeEducationTrainingCertsAffiliation = await _context.TblResumeEducationTrainingCertsAffiliations.FindAsync(id);
            if (tblResumeEducationTrainingCertsAffiliation == null)
            {
                return NotFound();
            }
            return View(tblResumeEducationTrainingCertsAffiliation);
        }

        // POST: ResumeCerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResumeId,EducationTrainingCertAfilliation,Abbreviation,IssuedBy")] TblResumeEducationTrainingCertsAffiliation tblResumeEducationTrainingCertsAffiliation)
        {
            if (id != tblResumeEducationTrainingCertsAffiliation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResumeEducationTrainingCertsAffiliation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResumeEducationTrainingCertsAffiliationExists(tblResumeEducationTrainingCertsAffiliation.Id))
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
            return View(tblResumeEducationTrainingCertsAffiliation);
        }

        // GET: ResumeCerts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeEducationTrainingCertsAffiliation = await _context.TblResumeEducationTrainingCertsAffiliations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeEducationTrainingCertsAffiliation == null)
            {
                return NotFound();
            }

            return View(tblResumeEducationTrainingCertsAffiliation);
        }

        // POST: ResumeCerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResumeEducationTrainingCertsAffiliation = await _context.TblResumeEducationTrainingCertsAffiliations.FindAsync(id);
            _context.TblResumeEducationTrainingCertsAffiliations.Remove(tblResumeEducationTrainingCertsAffiliation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResumeEducationTrainingCertsAffiliationExists(int id)
        {
            return _context.TblResumeEducationTrainingCertsAffiliations.Any(e => e.Id == id);
        }
    }
}
