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
    public class AnnualReviewGeneralQuestionResponsesController : Controller
    {
        private readonly ReviewContext _context;

        public AnnualReviewGeneralQuestionResponsesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: AnnualReviewGeneralQuestionResponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewGeneralQuestionResponses.ToListAsync());
        }

        // GET: AnnualReviewGeneralQuestionResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewGeneralQuestionResponse = await _context.TblAnnualReviewGeneralQuestionResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewGeneralQuestionResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewGeneralQuestionResponse);
        }

        // GET: AnnualReviewGeneralQuestionResponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnualReviewGeneralQuestionResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnnualReviewId,GeneralQuestionId,GeneralQuestionResponse")] TblAnnualReviewGeneralQuestionResponse tblAnnualReviewGeneralQuestionResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewGeneralQuestionResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewGeneralQuestionResponse);
        }

        // GET: AnnualReviewGeneralQuestionResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewGeneralQuestionResponse = await _context.TblAnnualReviewGeneralQuestionResponses.FindAsync(id);
            if (tblAnnualReviewGeneralQuestionResponse == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewGeneralQuestionResponse);
        }

        // POST: AnnualReviewGeneralQuestionResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnnualReviewId,GeneralQuestionId,GeneralQuestionResponse")] TblAnnualReviewGeneralQuestionResponse tblAnnualReviewGeneralQuestionResponse)
        {
            if (id != tblAnnualReviewGeneralQuestionResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewGeneralQuestionResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewGeneralQuestionResponseExists(tblAnnualReviewGeneralQuestionResponse.Id))
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
            return View(tblAnnualReviewGeneralQuestionResponse);
        }

        // GET: AnnualReviewGeneralQuestionResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewGeneralQuestionResponse = await _context.TblAnnualReviewGeneralQuestionResponses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewGeneralQuestionResponse == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewGeneralQuestionResponse);
        }

        // POST: AnnualReviewGeneralQuestionResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewGeneralQuestionResponse = await _context.TblAnnualReviewGeneralQuestionResponses.FindAsync(id);
            _context.TblAnnualReviewGeneralQuestionResponses.Remove(tblAnnualReviewGeneralQuestionResponse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewGeneralQuestionResponseExists(int id)
        {
            return _context.TblAnnualReviewGeneralQuestionResponses.Any(e => e.Id == id);
        }
    }
}
