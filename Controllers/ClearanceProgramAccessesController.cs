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
    public class ClearanceProgramAccessesController : Controller
    {
        private readonly ReviewContext _context;

        public ClearanceProgramAccessesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ClearanceProgramAccesses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblClearanceProgramAccesses.ToListAsync());
        }

        // GET: ClearanceProgramAccesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceProgramAccess = await _context.TblClearanceProgramAccesses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearanceProgramAccess == null)
            {
                return NotFound();
            }

            return View(tblClearanceProgramAccess);
        }

        // GET: ClearanceProgramAccesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClearanceProgramAccesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProgramAccess")] TblClearanceProgramAccess tblClearanceProgramAccess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClearanceProgramAccess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClearanceProgramAccess);
        }

        // GET: ClearanceProgramAccesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceProgramAccess = await _context.TblClearanceProgramAccesses.FindAsync(id);
            if (tblClearanceProgramAccess == null)
            {
                return NotFound();
            }
            return View(tblClearanceProgramAccess);
        }

        // POST: ClearanceProgramAccesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProgramAccess")] TblClearanceProgramAccess tblClearanceProgramAccess)
        {
            if (id != tblClearanceProgramAccess.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClearanceProgramAccess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClearanceProgramAccessExists(tblClearanceProgramAccess.Id))
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
            return View(tblClearanceProgramAccess);
        }

        // GET: ClearanceProgramAccesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClearanceProgramAccess = await _context.TblClearanceProgramAccesses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClearanceProgramAccess == null)
            {
                return NotFound();
            }

            return View(tblClearanceProgramAccess);
        }

        // POST: ClearanceProgramAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClearanceProgramAccess = await _context.TblClearanceProgramAccesses.FindAsync(id);
            _context.TblClearanceProgramAccesses.Remove(tblClearanceProgramAccess);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClearanceProgramAccessExists(int id)
        {
            return _context.TblClearanceProgramAccesses.Any(e => e.Id == id);
        }
    }
}
