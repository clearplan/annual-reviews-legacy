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
    public class ResumeFilesController : Controller
    {
        private readonly ReviewContext _context;

        public ResumeFilesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResumeFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResumeFiles.ToListAsync());
        }

        // GET: ResumeFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeFile = await _context.TblResumeFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeFile == null)
            {
                return NotFound();
            }

            return View(tblResumeFile);
        }

        // GET: ResumeFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResumeFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResourceId,DateCreated,LastModified,CreatedBy,ModifiedBy,FileName,FilePath,ResumeId")] TblResumeFile tblResumeFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResumeFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResumeFile);
        }

        // GET: ResumeFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeFile = await _context.TblResumeFiles.FindAsync(id);
            if (tblResumeFile == null)
            {
                return NotFound();
            }
            return View(tblResumeFile);
        }

        // POST: ResumeFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResourceId,DateCreated,LastModified,CreatedBy,ModifiedBy,FileName,FilePath,ResumeId")] TblResumeFile tblResumeFile)
        {
            if (id != tblResumeFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResumeFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResumeFileExists(tblResumeFile.Id))
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
            return View(tblResumeFile);
        }

        // GET: ResumeFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeFile = await _context.TblResumeFiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeFile == null)
            {
                return NotFound();
            }

            return View(tblResumeFile);
        }

        // POST: ResumeFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResumeFile = await _context.TblResumeFiles.FindAsync(id);
            _context.TblResumeFiles.Remove(tblResumeFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResumeFileExists(int id)
        {
            return _context.TblResumeFiles.Any(e => e.Id == id);
        }
    }
}
