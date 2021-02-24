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
    public class ToolsoftheTradeCategoriesController : Controller
    {
        private readonly ReviewContext _context;

        public ToolsoftheTradeCategoriesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ToolsoftheTradeCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewToolsoftheTradeCategories.ToListAsync());
        }

        // GET: ToolsoftheTradeCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewToolsoftheTradeCategory = await _context.TblAnnualReviewToolsoftheTradeCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewToolsoftheTradeCategory == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewToolsoftheTradeCategory);
        }

        // GET: ToolsoftheTradeCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToolsoftheTradeCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ToolCategoryName")] TblAnnualReviewToolsoftheTradeCategory tblAnnualReviewToolsoftheTradeCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewToolsoftheTradeCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewToolsoftheTradeCategory);
        }

        // GET: ToolsoftheTradeCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewToolsoftheTradeCategory = await _context.TblAnnualReviewToolsoftheTradeCategories.FindAsync(id);
            if (tblAnnualReviewToolsoftheTradeCategory == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewToolsoftheTradeCategory);
        }

        // POST: ToolsoftheTradeCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ToolCategoryName")] TblAnnualReviewToolsoftheTradeCategory tblAnnualReviewToolsoftheTradeCategory)
        {
            if (id != tblAnnualReviewToolsoftheTradeCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewToolsoftheTradeCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewToolsoftheTradeCategoryExists(tblAnnualReviewToolsoftheTradeCategory.Id))
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
            return View(tblAnnualReviewToolsoftheTradeCategory);
        }

        // GET: ToolsoftheTradeCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewToolsoftheTradeCategory = await _context.TblAnnualReviewToolsoftheTradeCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewToolsoftheTradeCategory == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewToolsoftheTradeCategory);
        }

        // POST: ToolsoftheTradeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewToolsoftheTradeCategory = await _context.TblAnnualReviewToolsoftheTradeCategories.FindAsync(id);
            _context.TblAnnualReviewToolsoftheTradeCategories.Remove(tblAnnualReviewToolsoftheTradeCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewToolsoftheTradeCategoryExists(int id)
        {
            return _context.TblAnnualReviewToolsoftheTradeCategories.Any(e => e.Id == id);
        }
    }
}
