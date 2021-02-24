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
    public class AnnualReviewAdditionalToolsoftheTradeResponsesController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewAdditionalToolsoftheTradeResponsesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: AnnualReviewAdditionalToolsoftheTradeResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewAdditionalToolsoftheTradeResponses.ToListAsync());
        }

        // GET: AnnualReviewAdditionalToolsoftheTradeResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewAdditionalToolsoftheTradeResponse = await _context.TblAnnualReviewAdditionalToolsoftheTradeResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewAdditionalToolsoftheTradeResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewAdditionalToolsoftheTradeResponse);
        }

        // GET: AnnualReviewAdditionalToolsoftheTradeResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviewAdditionalToolsoftheTradeResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnnualReviewId,AdditionalTooloftheTrade,ToolsoftheTradeRating")] TblAnnualReviewAdditionalToolsoftheTradeResponse tblAnnualReviewAdditionalToolsoftheTradeResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewAdditionalToolsoftheTradeResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewAdditionalToolsoftheTradeResponse);
        }

        // GET: AnnualReviewAdditionalToolsoftheTradeResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewAdditionalToolsoftheTradeResponse = await _context.TblAnnualReviewAdditionalToolsoftheTradeResponses.FindAsync(id);
            if (tblAnnualReviewAdditionalToolsoftheTradeResponse == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewAdditionalToolsoftheTradeResponse);
        }

        // POST: AnnualReviewAdditionalToolsoftheTradeResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnnualReviewId,AdditionalTooloftheTrade,ToolsoftheTradeRating")] TblAnnualReviewAdditionalToolsoftheTradeResponse tblAnnualReviewAdditionalToolsoftheTradeResponse)
        {
            if (id != tblAnnualReviewAdditionalToolsoftheTradeResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewAdditionalToolsoftheTradeResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewAdditionalToolsoftheTradeResponseExists(tblAnnualReviewAdditionalToolsoftheTradeResponse.Id))
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
            return View(tblAnnualReviewAdditionalToolsoftheTradeResponse);
        }

        // GET: AnnualReviewAdditionalToolsoftheTradeResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewAdditionalToolsoftheTradeResponse = await _context.TblAnnualReviewAdditionalToolsoftheTradeResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewAdditionalToolsoftheTradeResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewAdditionalToolsoftheTradeResponse);
        }

        // POST: AnnualReviewAdditionalToolsoftheTradeResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewAdditionalToolsoftheTradeResponse = await _context.TblAnnualReviewAdditionalToolsoftheTradeResponses.FindAsync(id);
            _context.TblAnnualReviewAdditionalToolsoftheTradeResponses.Remove(tblAnnualReviewAdditionalToolsoftheTradeResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewAdditionalToolsoftheTradeResponseExists(int id)
        {
            return _context.TblAnnualReviewAdditionalToolsoftheTradeResponses.Any(e => e.Id == id);
        }
    }
}
