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
    public class ClearanceAdditionalInvestigationsController : Controller
    {
        private readonly ReviewContext _context;

        public ClearanceAdditionalInvestigationsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ClearanceAdditionalInvestigations
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblClearanceAdditionalInvestigations.ToListAsync());
        }

        // GET: ClearanceAdditionalInvestigations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceAdditionalInvestigation = await _context.TblClearanceAdditionalInvestigations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearanceAdditionalInvestigation == null)
            {
                return NotFound();
            }

            return View(tblClearanceAdditionalInvestigation);
        }

        // GET: ClearanceAdditionalInvestigations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClearanceAdditionalInvestigations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdditionalInvestigation")] TblClearanceAdditionalInvestigation tblClearanceAdditionalInvestigation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClearanceAdditionalInvestigation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClearanceAdditionalInvestigation);
        }

        // GET: ClearanceAdditionalInvestigations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceAdditionalInvestigation = await _context.TblClearanceAdditionalInvestigations.FindAsync(id);
            if (tblClearanceAdditionalInvestigation == null)
            {
                return NotFound();
            }
            return View(tblClearanceAdditionalInvestigation);
        }

        // POST: ClearanceAdditionalInvestigations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdditionalInvestigation")] TblClearanceAdditionalInvestigation tblClearanceAdditionalInvestigation)
        {
            if (id != tblClearanceAdditionalInvestigation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClearanceAdditionalInvestigation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClearanceAdditionalInvestigationExists(tblClearanceAdditionalInvestigation.Id))
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
            return View(tblClearanceAdditionalInvestigation);
        }

        // GET: ClearanceAdditionalInvestigations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceAdditionalInvestigation = await _context.TblClearanceAdditionalInvestigations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearanceAdditionalInvestigation == null)
            {
                return NotFound();
            }

            return View(tblClearanceAdditionalInvestigation);
        }

        // POST: ClearanceAdditionalInvestigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClearanceAdditionalInvestigation = await _context.TblClearanceAdditionalInvestigations.FindAsync(id);
            _context.TblClearanceAdditionalInvestigations.Remove(tblClearanceAdditionalInvestigation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClearanceAdditionalInvestigationExists(int id)
        {
            return _context.TblClearanceAdditionalInvestigations.Any(e => e.Id == id);
        }
    }
}
