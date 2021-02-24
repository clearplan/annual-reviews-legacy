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
    public class ResumesController : Controller
    {
        private readonly ReviewContext _context;

        public ResumesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Resumes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResumes.ToListAsync());
        }

        // GET: Resumes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResume = await _context.TblResumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResume == null)
            {
                return NotFound();
            }

            return View(tblResume);
        }

        // GET: Resumes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resumes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResourceId,DateCreated,LastModified,CreatedBy,ModifiedBy,Overview,ResumeStatusId,ResumeName,ReviewedByManager")] TblResume tblResume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResume);
        }

        // GET: Resumes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResume = await _context.TblResumes.FindAsync(id);
            if (tblResume == null)
            {
                return NotFound();
            }
            return View(tblResume);
        }

        // POST: Resumes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResourceId,DateCreated,LastModified,CreatedBy,ModifiedBy,Overview,ResumeStatusId,ResumeName,ReviewedByManager")] TblResume tblResume)
        {
            if (id != tblResume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResumeExists(tblResume.Id))
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
            return View(tblResume);
        }

        // GET: Resumes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResume = await _context.TblResumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResume == null)
            {
                return NotFound();
            }

            return View(tblResume);
        }

        // POST: Resumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResume = await _context.TblResumes.FindAsync(id);
            _context.TblResumes.Remove(tblResume);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResumeExists(int id)
        {
            return _context.TblResumes.Any(e => e.Id == id);
        }
    }
}
