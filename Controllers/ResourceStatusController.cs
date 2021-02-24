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
    public class ResourceStatusController : Controller
    {
        private readonly ReviewContext _context;

        public ResourceStatusController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResourceStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResourceStatuses.ToListAsync());
        }

        // GET: ResourceStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResourceStatus = await _context.TblResourceStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResourceStatus == null)
            {
                return NotFound();
            }

            return View(tblResourceStatus);
        }

        // GET: ResourceStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResourceStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] TblResourceStatus tblResourceStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResourceStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResourceStatus);
        }

        // GET: ResourceStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResourceStatus = await _context.TblResourceStatuses.FindAsync(id);
            if (tblResourceStatus == null)
            {
                return NotFound();
            }
            return View(tblResourceStatus);
        }

        // POST: ResourceStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] TblResourceStatus tblResourceStatus)
        {
            if (id != tblResourceStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResourceStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResourceStatusExists(tblResourceStatus.Id))
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
            return View(tblResourceStatus);
        }

        // GET: ResourceStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResourceStatus = await _context.TblResourceStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResourceStatus == null)
            {
                return NotFound();
            }

            return View(tblResourceStatus);
        }

        // POST: ResourceStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResourceStatus = await _context.TblResourceStatuses.FindAsync(id);
            _context.TblResourceStatuses.Remove(tblResourceStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResourceStatusExists(int id)
        {
            return _context.TblResourceStatuses.Any(e => e.Id == id);
        }
    }
}
