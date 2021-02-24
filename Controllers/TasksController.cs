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
    public class TasksController : Controller
    {
        private readonly ReviewContext _context;

        public TasksController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTasks.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTask = await _context.TblTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTask == null)
            {
                return NotFound();
            }

            return View(tblTask);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssignedTo,TaskName,DueDate,TaskStatusId,TaskTypeId,AssociatedRecordId,DateCreated,LastModified,CreatedBy,ModifiedBy,Archived")] TblTask tblTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTask);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTask = await _context.TblTasks.FindAsync(id);
            if (tblTask == null)
            {
                return NotFound();
            }
            return View(tblTask);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssignedTo,TaskName,DueDate,TaskStatusId,TaskTypeId,AssociatedRecordId,DateCreated,LastModified,CreatedBy,ModifiedBy,Archived")] TblTask tblTask)
        {
            if (id != tblTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTaskExists(tblTask.Id))
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
            return View(tblTask);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTask = await _context.TblTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTask == null)
            {
                return NotFound();
            }

            return View(tblTask);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTask = await _context.TblTasks.FindAsync(id);
            _context.TblTasks.Remove(tblTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTaskExists(int id)
        {
            return _context.TblTasks.Any(e => e.Id == id);
        }
    }
}
