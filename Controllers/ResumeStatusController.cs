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
    public class ResumeStatusController : Controller
    {
        private readonly ReviewContext _context;

        public ResumeStatusController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResumeStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResumeStatuses.ToListAsync());
        }

        // GET: ResumeStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeStatus = await _context.TblResumeStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeStatus == null)
            {
                return NotFound();
            }

            return View(tblResumeStatus);
        }

        // GET: ResumeStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResumeStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,IsDefault")] TblResumeStatus tblResumeStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResumeStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResumeStatus);
        }

        // GET: ResumeStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeStatus = await _context.TblResumeStatuses.FindAsync(id);
            if (tblResumeStatus == null)
            {
                return NotFound();
            }
            return View(tblResumeStatus);
        }

        // POST: ResumeStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,IsDefault")] TblResumeStatus tblResumeStatus)
        {
            if (id != tblResumeStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResumeStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResumeStatusExists(tblResumeStatus.Id))
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
            return View(tblResumeStatus);
        }

        // GET: ResumeStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeStatus = await _context.TblResumeStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeStatus == null)
            {
                return NotFound();
            }

            return View(tblResumeStatus);
        }

        // POST: ResumeStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResumeStatus = await _context.TblResumeStatuses.FindAsync(id);
            _context.TblResumeStatuses.Remove(tblResumeStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResumeStatusExists(int id)
        {
            return _context.TblResumeStatuses.Any(e => e.Id == id);
        }
    }
}
