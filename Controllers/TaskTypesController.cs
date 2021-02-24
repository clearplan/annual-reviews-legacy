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
    public class TaskTypesController : Controller
    {
        private readonly ReviewContext _context;

        public TaskTypesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: TaskTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTaskTypes.ToListAsync());
        }

        // GET: TaskTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTaskType = await _context.TblTaskTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTaskType == null)
            {
                return NotFound();
            }

            return View(tblTaskType);
        }

        // GET: TaskTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskType")] TblTaskType tblTaskType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTaskType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTaskType);
        }

        // GET: TaskTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTaskType = await _context.TblTaskTypes.FindAsync(id);
            if (tblTaskType == null)
            {
                return NotFound();
            }
            return View(tblTaskType);
        }

        // POST: TaskTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskType")] TblTaskType tblTaskType)
        {
            if (id != tblTaskType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTaskType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTaskTypeExists(tblTaskType.Id))
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
            return View(tblTaskType);
        }

        // GET: TaskTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTaskType = await _context.TblTaskTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTaskType == null)
            {
                return NotFound();
            }

            return View(tblTaskType);
        }

        // POST: TaskTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTaskType = await _context.TblTaskTypes.FindAsync(id);
            _context.TblTaskTypes.Remove(tblTaskType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTaskTypeExists(int id)
        {
            return _context.TblTaskTypes.Any(e => e.Id == id);
        }
    }
}
