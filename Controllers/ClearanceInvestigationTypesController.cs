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
    public class ClearanceInvestigationTypesController : Controller
    {
        private readonly ReviewContext _context;

        public ClearanceInvestigationTypesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ClearanceInvestigationTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblClearanceInvestigationTypes.ToListAsync());
        }

        // GET: ClearanceInvestigationTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceInvestigationType = await _context.TblClearanceInvestigationTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearanceInvestigationType == null)
            {
                return NotFound();
            }

            return View(tblClearanceInvestigationType);
        }

        // GET: ClearanceInvestigationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClearanceInvestigationTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvestigationType")] TblClearanceInvestigationType tblClearanceInvestigationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClearanceInvestigationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClearanceInvestigationType);
        }

        // GET: ClearanceInvestigationTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceInvestigationType = await _context.TblClearanceInvestigationTypes.FindAsync(id);
            if (tblClearanceInvestigationType == null)
            {
                return NotFound();
            }
            return View(tblClearanceInvestigationType);
        }

        // POST: ClearanceInvestigationTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvestigationType")] TblClearanceInvestigationType tblClearanceInvestigationType)
        {
            if (id != tblClearanceInvestigationType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClearanceInvestigationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClearanceInvestigationTypeExists(tblClearanceInvestigationType.Id))
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
            return View(tblClearanceInvestigationType);
        }

        // GET: ClearanceInvestigationTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceInvestigationType = await _context.TblClearanceInvestigationTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearanceInvestigationType == null)
            {
                return NotFound();
            }

            return View(tblClearanceInvestigationType);
        }

        // POST: ClearanceInvestigationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClearanceInvestigationType = await _context.TblClearanceInvestigationTypes.FindAsync(id);
            _context.TblClearanceInvestigationTypes.Remove(tblClearanceInvestigationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClearanceInvestigationTypeExists(int id)
        {
            return _context.TblClearanceInvestigationTypes.Any(e => e.Id == id);
        }
    }
}
