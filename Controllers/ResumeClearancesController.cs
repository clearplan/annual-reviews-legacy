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
    public class ResumeClearancesController : Controller
    {
        private readonly ReviewContext _context;

        public ResumeClearancesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResumeClearances
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResumeClearances.ToListAsync());
        }

        // GET: ResumeClearances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeClearance = await _context.TblResumeClearances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeClearance == null)
            {
                return NotFound();
            }

            return View(tblResumeClearance);
        }

        // GET: ResumeClearances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResumeClearances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResumeId,Clearance,IssuedBy,InvestigationType,ProgramAccess,AdditionalInvestigations")] TblResumeClearance tblResumeClearance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResumeClearance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResumeClearance);
        }

        // GET: ResumeClearances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeClearance = await _context.TblResumeClearances.FindAsync(id);
            if (tblResumeClearance == null)
            {
                return NotFound();
            }
            return View(tblResumeClearance);
        }

        // POST: ResumeClearances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResumeId,Clearance,IssuedBy,InvestigationType,ProgramAccess,AdditionalInvestigations")] TblResumeClearance tblResumeClearance)
        {
            if (id != tblResumeClearance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResumeClearance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResumeClearanceExists(tblResumeClearance.Id))
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
            return View(tblResumeClearance);
        }

        // GET: ResumeClearances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResumeClearance = await _context.TblResumeClearances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResumeClearance == null)
            {
                return NotFound();
            }

            return View(tblResumeClearance);
        }

        // POST: ResumeClearances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResumeClearance = await _context.TblResumeClearances.FindAsync(id);
            _context.TblResumeClearances.Remove(tblResumeClearance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResumeClearanceExists(int id)
        {
            return _context.TblResumeClearances.Any(e => e.Id == id);
        }
    }
}
