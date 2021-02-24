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
    public class ExperienceCapabilityScalesController : Controller
    {
        private readonly ReviewContext _context;

        public ExperienceCapabilityScalesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ExperienceCapabilityScales
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblExperienceCapabilityScales.ToListAsync());
        }

        // GET: ExperienceCapabilityScales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExperienceCapabilityScale = await _context.TblExperienceCapabilityScales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblExperienceCapabilityScale == null)
            {
                return NotFound();
            }

            return View(tblExperienceCapabilityScale);
        }

        // GET: ExperienceCapabilityScales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExperienceCapabilityScales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScaleNumber,ScaleDescription")] TblExperienceCapabilityScale tblExperienceCapabilityScale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblExperienceCapabilityScale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblExperienceCapabilityScale);
        }

        // GET: ExperienceCapabilityScales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExperienceCapabilityScale = await _context.TblExperienceCapabilityScales.FindAsync(id);
            if (tblExperienceCapabilityScale == null)
            {
                return NotFound();
            }
            return View(tblExperienceCapabilityScale);
        }

        // POST: ExperienceCapabilityScales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScaleNumber,ScaleDescription")] TblExperienceCapabilityScale tblExperienceCapabilityScale)
        {
            if (id != tblExperienceCapabilityScale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblExperienceCapabilityScale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblExperienceCapabilityScaleExists(tblExperienceCapabilityScale.Id))
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
            return View(tblExperienceCapabilityScale);
        }

        // GET: ExperienceCapabilityScales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExperienceCapabilityScale = await _context.TblExperienceCapabilityScales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblExperienceCapabilityScale == null)
            {
                return NotFound();
            }

            return View(tblExperienceCapabilityScale);
        }

        // POST: ExperienceCapabilityScales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblExperienceCapabilityScale = await _context.TblExperienceCapabilityScales.FindAsync(id);
            _context.TblExperienceCapabilityScales.Remove(tblExperienceCapabilityScale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblExperienceCapabilityScaleExists(int id)
        {
            return _context.TblExperienceCapabilityScales.Any(e => e.Id == id);
        }
    }
}
