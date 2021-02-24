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
    public class ResumeProjectExperiencesController : Controller
    {
        private readonly ReviewContext _context;

        public ResumeProjectExperiencesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResumeProjectExperiences
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResumeProjectExperiences.ToListAsync());
        }

        // GET: ResumeProjectExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeProjectExperience = await _context.TblResumeProjectExperiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeProjectExperience == null)
            {
                return NotFound();
            }

            return View(tblResumeProjectExperience);
        }

        // GET: ResumeProjectExperiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResumeProjectExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResumeId,ProjectTitle,StartDate,EndDate,ProjectExperienceDetails,CompanyOrganizationName,SortOrderNum")] TblResumeProjectExperience tblResumeProjectExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResumeProjectExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResumeProjectExperience);
        }

        // GET: ResumeProjectExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeProjectExperience = await _context.TblResumeProjectExperiences.FindAsync(id);
            if (tblResumeProjectExperience == null)
            {
                return NotFound();
            }
            return View(tblResumeProjectExperience);
        }

        // POST: ResumeProjectExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResumeId,ProjectTitle,StartDate,EndDate,ProjectExperienceDetails,CompanyOrganizationName,SortOrderNum")] TblResumeProjectExperience tblResumeProjectExperience)
        {
            if (id != tblResumeProjectExperience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResumeProjectExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResumeProjectExperienceExists(tblResumeProjectExperience.Id))
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
            return View(tblResumeProjectExperience);
        }

        // GET: ResumeProjectExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeProjectExperience = await _context.TblResumeProjectExperiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeProjectExperience == null)
            {
                return NotFound();
            }

            return View(tblResumeProjectExperience);
        }

        // POST: ResumeProjectExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResumeProjectExperience = await _context.TblResumeProjectExperiences.FindAsync(id);
            _context.TblResumeProjectExperiences.Remove(tblResumeProjectExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResumeProjectExperienceExists(int id)
        {
            return _context.TblResumeProjectExperiences.Any(e => e.Id == id);
        }
    }
}
