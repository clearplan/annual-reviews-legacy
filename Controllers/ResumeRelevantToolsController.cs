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
    public class ResumeRelevantToolsController : Controller
    {
        private readonly ReviewContext _context;

        public ResumeRelevantToolsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResumeRelevantTools
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResumeRelevantTools.ToListAsync());
        }

        // GET: ResumeRelevantTools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeRelevantTool = await _context.TblResumeRelevantTools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeRelevantTool == null)
            {
                return NotFound();
            }

            return View(tblResumeRelevantTool);
        }

        // GET: ResumeRelevantTools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResumeRelevantTools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResumeId,ToolsoftheTradeId")] TblResumeRelevantTool tblResumeRelevantTool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResumeRelevantTool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResumeRelevantTool);
        }

        // GET: ResumeRelevantTools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeRelevantTool = await _context.TblResumeRelevantTools.FindAsync(id);
            if (tblResumeRelevantTool == null)
            {
                return NotFound();
            }
            return View(tblResumeRelevantTool);
        }

        // POST: ResumeRelevantTools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResumeId,ToolsoftheTradeId")] TblResumeRelevantTool tblResumeRelevantTool)
        {
            if (id != tblResumeRelevantTool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResumeRelevantTool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResumeRelevantToolExists(tblResumeRelevantTool.Id))
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
            return View(tblResumeRelevantTool);
        }

        // GET: ResumeRelevantTools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeRelevantTool = await _context.TblResumeRelevantTools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeRelevantTool == null)
            {
                return NotFound();
            }

            return View(tblResumeRelevantTool);
        }

        // POST: ResumeRelevantTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResumeRelevantTool = await _context.TblResumeRelevantTools.FindAsync(id);
            _context.TblResumeRelevantTools.Remove(tblResumeRelevantTool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResumeRelevantToolExists(int id)
        {
            return _context.TblResumeRelevantTools.Any(e => e.Id == id);
        }
    }
}
