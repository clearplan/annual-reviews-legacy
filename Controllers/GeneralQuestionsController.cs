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
    public class GeneralQuestionsController : Controller
    {
        private readonly ReviewContext _context;

        public GeneralQuestionsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: GeneralQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblAnnualReviewGeneralQuestions.ToListAsync());
        }

        // GET: GeneralQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewGeneralQuestion = await _context.TblAnnualReviewGeneralQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewGeneralQuestion == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewGeneralQuestion);
        }

        // GET: GeneralQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuestionNumber,QuestionText")] TblAnnualReviewGeneralQuestion tblAnnualReviewGeneralQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAnnualReviewGeneralQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAnnualReviewGeneralQuestion);
        }

        // GET: GeneralQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewGeneralQuestion = await _context.TblAnnualReviewGeneralQuestions.FindAsync(id);
            if (tblAnnualReviewGeneralQuestion == null)
            {
                return NotFound();
            }
            return View(tblAnnualReviewGeneralQuestion);
        }

        // POST: GeneralQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionNumber,QuestionText")] TblAnnualReviewGeneralQuestion tblAnnualReviewGeneralQuestion)
        {
            if (id != tblAnnualReviewGeneralQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAnnualReviewGeneralQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAnnualReviewGeneralQuestionExists(tblAnnualReviewGeneralQuestion.Id))
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
            return View(tblAnnualReviewGeneralQuestion);
        }

        // GET: GeneralQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAnnualReviewGeneralQuestion = await _context.TblAnnualReviewGeneralQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblAnnualReviewGeneralQuestion == null)
            {
                return NotFound();
            }

            return View(tblAnnualReviewGeneralQuestion);
        }

        // POST: GeneralQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAnnualReviewGeneralQuestion = await _context.TblAnnualReviewGeneralQuestions.FindAsync(id);
            _context.TblAnnualReviewGeneralQuestions.Remove(tblAnnualReviewGeneralQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAnnualReviewGeneralQuestionExists(int id)
        {
            return _context.TblAnnualReviewGeneralQuestions.Any(e => e.Id == id);
        }
    }
}
