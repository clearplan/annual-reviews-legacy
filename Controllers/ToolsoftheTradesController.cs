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
    public class ToolsoftheTradesController : Controller
    {
        private readonly ReviewContext _context;

        public ToolsoftheTradesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ToolsoftheTrades
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewToolsoftheTrades.ToListAsync());
        }

        // GET: ToolsoftheTrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewToolsoftheTrade = await _context.TblAnnualReviewToolsoftheTrades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewToolsoftheTrade == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewToolsoftheTrade);
        }

        // GET: ToolsoftheTrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToolsoftheTrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ToolCategoryId,ToolName")] TblAnnualReviewToolsoftheTrade tblAnnualReviewToolsoftheTrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewToolsoftheTrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewToolsoftheTrade);
        }

        // GET: ToolsoftheTrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewToolsoftheTrade = await _context.TblAnnualReviewToolsoftheTrades.FindAsync(id);
            if (tblAnnualReviewToolsoftheTrade == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewToolsoftheTrade);
        }

        // POST: ToolsoftheTrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ToolCategoryId,ToolName")] TblAnnualReviewToolsoftheTrade tblAnnualReviewToolsoftheTrade)
        {
            if (id != tblAnnualReviewToolsoftheTrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewToolsoftheTrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewToolsoftheTradeExists(tblAnnualReviewToolsoftheTrade.Id))
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
            return View(tblAnnualReviewToolsoftheTrade);
        }

        // GET: ToolsoftheTrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewToolsoftheTrade = await _context.TblAnnualReviewToolsoftheTrades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewToolsoftheTrade == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewToolsoftheTrade);
        }

        // POST: ToolsoftheTrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewToolsoftheTrade = await _context.TblAnnualReviewToolsoftheTrades.FindAsync(id);
            _context.TblAnnualReviewToolsoftheTrades.Remove(tblAnnualReviewToolsoftheTrade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewToolsoftheTradeExists(int id)
        {
            return _context.TblAnnualReviewToolsoftheTrades.Any(e => e.Id == id);
        }
    }
}
