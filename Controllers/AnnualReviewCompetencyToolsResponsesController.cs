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
    public class AnnualReviewCompetencyToolsResponsesController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewCompetencyToolsResponsesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: AnnualReviewCompetencyToolsResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewCompetencyToolsResponses.ToListAsync());
        }

        // GET: AnnualReviewCompetencyToolsResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewCompetencyToolsResponse = await _context.TblAnnualReviewCompetencyToolsResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewCompetencyToolsResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewCompetencyToolsResponse);
        }

        // GET: AnnualReviewCompetencyToolsResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviewCompetencyToolsResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnnualReviewId,CompetencyResponseId,ToolId")] TblAnnualReviewCompetencyToolsResponse tblAnnualReviewCompetencyToolsResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewCompetencyToolsResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewCompetencyToolsResponse);
        }

        // GET: AnnualReviewCompetencyToolsResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewCompetencyToolsResponse = await _context.TblAnnualReviewCompetencyToolsResponses.FindAsync(id);
            if (tblAnnualReviewCompetencyToolsResponse == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewCompetencyToolsResponse);
        }

        // POST: AnnualReviewCompetencyToolsResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnnualReviewId,CompetencyResponseId,ToolId")] TblAnnualReviewCompetencyToolsResponse tblAnnualReviewCompetencyToolsResponse)
        {
            if (id != tblAnnualReviewCompetencyToolsResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewCompetencyToolsResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewCompetencyToolsResponseExists(tblAnnualReviewCompetencyToolsResponse.Id))
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
            return View(tblAnnualReviewCompetencyToolsResponse);
        }

        // GET: AnnualReviewCompetencyToolsResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewCompetencyToolsResponse = await _context.TblAnnualReviewCompetencyToolsResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewCompetencyToolsResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewCompetencyToolsResponse);
        }

        // POST: AnnualReviewCompetencyToolsResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewCompetencyToolsResponse = await _context.TblAnnualReviewCompetencyToolsResponses.FindAsync(id);
            _context.TblAnnualReviewCompetencyToolsResponses.Remove(tblAnnualReviewCompetencyToolsResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewCompetencyToolsResponseExists(int id)
        {
            return _context.TblAnnualReviewCompetencyToolsResponses.Any(e => e.Id == id);
        }
    }
}
