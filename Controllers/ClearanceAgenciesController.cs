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
    public class ClearanceAgenciesController : Controller
    {
        private readonly ReviewContext _context;

        public ClearanceAgenciesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ClearanceAgencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblClearanceAgencies.ToListAsync());
        }

        // GET: ClearanceAgencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceAgency = await _context.TblClearanceAgencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearanceAgency == null)
            {
                return NotFound();
            }

            return View(tblClearanceAgency);
        }

        // GET: ClearanceAgencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClearanceAgencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Agency")] TblClearanceAgency tblClearanceAgency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClearanceAgency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClearanceAgency);
        }

        // GET: ClearanceAgencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceAgency = await _context.TblClearanceAgencies.FindAsync(id);
            if (tblClearanceAgency == null)
            {
                return NotFound();
            }
            return View(tblClearanceAgency);
        }

        // POST: ClearanceAgencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Agency")] TblClearanceAgency tblClearanceAgency)
        {
            if (id != tblClearanceAgency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClearanceAgency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClearanceAgencyExists(tblClearanceAgency.Id))
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
            return View(tblClearanceAgency);
        }

        // GET: ClearanceAgencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceAgency = await _context.TblClearanceAgencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearanceAgency == null)
            {
                return NotFound();
            }

            return View(tblClearanceAgency);
        }

        // POST: ClearanceAgencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClearanceAgency = await _context.TblClearanceAgencies.FindAsync(id);
            _context.TblClearanceAgencies.Remove(tblClearanceAgency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClearanceAgencyExists(int id)
        {
            return _context.TblClearanceAgencies.Any(e => e.Id == id);
        }
    }
}
