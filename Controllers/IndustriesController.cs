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
    public class IndustriesController : Controller
    {
        private readonly ReviewContext _context;

        public IndustriesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Industries
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblIndustries.ToListAsync());
        }

        // GET: Industries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIndustry = await _context.TblIndustries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblIndustry == null)
            {
                return NotFound();
            }

            return View(tblIndustry);
        }

        // GET: Industries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Industries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Industry")] TblIndustry tblIndustry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblIndustry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblIndustry);
        }

        // GET: Industries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIndustry = await _context.TblIndustries.FindAsync(id);
            if (tblIndustry == null)
            {
                return NotFound();
            }
            return View(tblIndustry);
        }

        // POST: Industries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Industry")] TblIndustry tblIndustry)
        {
            if (id != tblIndustry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblIndustry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblIndustryExists(tblIndustry.Id))
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
            return View(tblIndustry);
        }

        // GET: Industries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIndustry = await _context.TblIndustries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblIndustry == null)
            {
                return NotFound();
            }

            return View(tblIndustry);
        }

        // POST: Industries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblIndustry = await _context.TblIndustries.FindAsync(id);
            _context.TblIndustries.Remove(tblIndustry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblIndustryExists(int id)
        {
            return _context.TblIndustries.Any(e => e.Id == id);
        }
    }
}
