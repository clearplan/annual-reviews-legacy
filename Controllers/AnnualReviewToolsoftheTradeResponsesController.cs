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
    public class AnnualReviewToolsoftheTradeResponsesController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewToolsoftheTradeResponsesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: AnnualReviewToolsoftheTradeResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewToolsoftheTradeResponses.ToListAsync());
        }

        // GET: AnnualReviewToolsoftheTradeResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewToolsoftheTradeResponse = await _context.TblAnnualReviewToolsoftheTradeResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewToolsoftheTradeResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewToolsoftheTradeResponse);
        }

        // GET: AnnualReviewToolsoftheTradeResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviewToolsoftheTradeResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnnualReviewId,ToolsoftheTradeId,ToolsoftheTradeRating")] TblAnnualReviewToolsoftheTradeResponse tblAnnualReviewToolsoftheTradeResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewToolsoftheTradeResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewToolsoftheTradeResponse);
        }

        // GET: AnnualReviewToolsoftheTradeResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewToolsoftheTradeResponse = await _context.TblAnnualReviewToolsoftheTradeResponses.FindAsync(id);
            if (tblAnnualReviewToolsoftheTradeResponse == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewToolsoftheTradeResponse);
        }

        // POST: AnnualReviewToolsoftheTradeResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnnualReviewId,ToolsoftheTradeId,ToolsoftheTradeRating")] TblAnnualReviewToolsoftheTradeResponse tblAnnualReviewToolsoftheTradeResponse)
        {
            if (id != tblAnnualReviewToolsoftheTradeResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewToolsoftheTradeResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewToolsoftheTradeResponseExists(tblAnnualReviewToolsoftheTradeResponse.Id))
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
            return View(tblAnnualReviewToolsoftheTradeResponse);
        }

        // GET: AnnualReviewToolsoftheTradeResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewToolsoftheTradeResponse = await _context.TblAnnualReviewToolsoftheTradeResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewToolsoftheTradeResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewToolsoftheTradeResponse);
        }

        // POST: AnnualReviewToolsoftheTradeResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewToolsoftheTradeResponse = await _context.TblAnnualReviewToolsoftheTradeResponses.FindAsync(id);
            _context.TblAnnualReviewToolsoftheTradeResponses.Remove(tblAnnualReviewToolsoftheTradeResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewToolsoftheTradeResponseExists(int id)
        {
            return _context.TblAnnualReviewToolsoftheTradeResponses.Any(e => e.Id == id);
        }
    }
}
