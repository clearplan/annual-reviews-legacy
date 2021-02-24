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
    public class TaskStatusController : Controller
    {
        private readonly ReviewContext _context;

        public TaskStatusController(ReviewContext context)
        {
            _context = context;
        }

        // GET: TaskStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTaskStatuses.ToListAsync());
        }

        // GET: TaskStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTaskStatus = await _context.TblTaskStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTaskStatus == null)
            {
                return NotFound();
            }

            return View(tblTaskStatus);
        }

        // GET: TaskStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,IsDefault")] TblTaskStatus tblTaskStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTaskStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTaskStatus);
        }

        // GET: TaskStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTaskStatus = await _context.TblTaskStatuses.FindAsync(id);
            if (tblTaskStatus == null)
            {
                return NotFound();
            }
            return View(tblTaskStatus);
        }

        // POST: TaskStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,IsDefault")] TblTaskStatus tblTaskStatus)
        {
            if (id != tblTaskStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTaskStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTaskStatusExists(tblTaskStatus.Id))
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
            return View(tblTaskStatus);
        }

        // GET: TaskStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTaskStatus = await _context.TblTaskStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTaskStatus == null)
            {
                return NotFound();
            }

            return View(tblTaskStatus);
        }

        // POST: TaskStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTaskStatus = await _context.TblTaskStatuses.FindAsync(id);
            _context.TblTaskStatuses.Remove(tblTaskStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTaskStatusExists(int id)
        {
            return _context.TblTaskStatuses.Any(e => e.Id == id);
        }
    }
}
