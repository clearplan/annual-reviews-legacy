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
    public class ResumeAdditionalRelevantToolsController : Controller
    {
        private readonly ReviewContext _context;

        public ResumeAdditionalRelevantToolsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResumeAdditionalRelevantTools
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResumeAdditionalRelevantTools.ToListAsync());
        }

        // GET: ResumeAdditionalRelevantTools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeAdditionalRelevantTool = await _context.TblResumeAdditionalRelevantTools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeAdditionalRelevantTool == null)
            {
                return NotFound();
            }

            return View(tblResumeAdditionalRelevantTool);
        }

        // GET: ResumeAdditionalRelevantTools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResumeAdditionalRelevantTools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResumeId,AdditionalTools")] TblResumeAdditionalRelevantTool tblResumeAdditionalRelevantTool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResumeAdditionalRelevantTool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResumeAdditionalRelevantTool);
        }

        // GET: ResumeAdditionalRelevantTools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeAdditionalRelevantTool = await _context.TblResumeAdditionalRelevantTools.FindAsync(id);
            if (tblResumeAdditionalRelevantTool == null)
            {
                return NotFound();
            }
            return View(tblResumeAdditionalRelevantTool);
        }

        // POST: ResumeAdditionalRelevantTools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResumeId,AdditionalTools")] TblResumeAdditionalRelevantTool tblResumeAdditionalRelevantTool)
        {
            if (id != tblResumeAdditionalRelevantTool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResumeAdditionalRelevantTool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResumeAdditionalRelevantToolExists(tblResumeAdditionalRelevantTool.Id))
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
            return View(tblResumeAdditionalRelevantTool);
        }

        // GET: ResumeAdditionalRelevantTools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeAdditionalRelevantTool = await _context.TblResumeAdditionalRelevantTools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeAdditionalRelevantTool == null)
            {
                return NotFound();
            }

            return View(tblResumeAdditionalRelevantTool);
        }

        // POST: ResumeAdditionalRelevantTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResumeAdditionalRelevantTool = await _context.TblResumeAdditionalRelevantTools.FindAsync(id);
            _context.TblResumeAdditionalRelevantTools.Remove(tblResumeAdditionalRelevantTool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResumeAdditionalRelevantToolExists(int id)
        {
            return _context.TblResumeAdditionalRelevantTools.Any(e => e.Id == id);
        }
    }
}
