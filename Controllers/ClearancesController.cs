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
    public class ClearancesController : Controller
    {
        private readonly ReviewContext _context;

        public ClearancesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Clearances
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblClearances.ToListAsync());
        }

        // GET: Clearances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearance = await _context.TblClearances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearance == null)
            {
                return NotFound();
            }

            return View(tblClearance);
        }

        // GET: Clearances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clearances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Clearance")] TblClearance tblClearance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClearance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClearance);
        }

        // GET: Clearances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearance = await _context.TblClearances.FindAsync(id);
            if (tblClearance == null)
            {
                return NotFound();
            }
            return View(tblClearance);
        }

        // POST: Clearances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Clearance")] TblClearance tblClearance)
        {
            if (id != tblClearance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClearance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClearanceExists(tblClearance.Id))
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
            return View(tblClearance);
        }

        // GET: Clearances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearance = await _context.TblClearances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearance == null)
            {
                return NotFound();
            }

            return View(tblClearance);
        }

        // POST: Clearances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClearance = await _context.TblClearances.FindAsync(id);
            _context.TblClearances.Remove(tblClearance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClearanceExists(int id)
        {
            return _context.TblClearances.Any(e => e.Id == id);
        }
    }
}
