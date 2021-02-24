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
    public class ResumePositionHistoriesController : Controller
    {
        private readonly ReviewContext _context;

        public ResumePositionHistoriesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResumePositionHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResumePositionHistories.ToListAsync());
        }

        // GET: ResumePositionHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumePositionHistory = await _context.TblResumePositionHistories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumePositionHistory == null)
            {
                return NotFound();
            }

            return View(tblResumePositionHistory);
        }

        // GET: ResumePositionHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResumePositionHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResumeId,PositionTitle,DepartmentDivision,CompanyOrganizationName,StartDate,EndDate,PresentPosition,SortOrderNum")] TblResumePositionHistory tblResumePositionHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResumePositionHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResumePositionHistory);
        }

        // GET: ResumePositionHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumePositionHistory = await _context.TblResumePositionHistories.FindAsync(id);
            if (tblResumePositionHistory == null)
            {
                return NotFound();
            }
            return View(tblResumePositionHistory);
        }

        // POST: ResumePositionHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResumeId,PositionTitle,DepartmentDivision,CompanyOrganizationName,StartDate,EndDate,PresentPosition,SortOrderNum")] TblResumePositionHistory tblResumePositionHistory)
        {
            if (id != tblResumePositionHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResumePositionHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResumePositionHistoryExists(tblResumePositionHistory.Id))
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
            return View(tblResumePositionHistory);
        }

        // GET: ResumePositionHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumePositionHistory = await _context.TblResumePositionHistories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumePositionHistory == null)
            {
                return NotFound();
            }

            return View(tblResumePositionHistory);
        }

        // POST: ResumePositionHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResumePositionHistory = await _context.TblResumePositionHistories.FindAsync(id);
            _context.TblResumePositionHistories.Remove(tblResumePositionHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResumePositionHistoryExists(int id)
        {
            return _context.TblResumePositionHistories.Any(e => e.Id == id);
        }
    }
}
