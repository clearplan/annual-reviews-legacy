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
    public class KudosController : Controller
    {
        private readonly ReviewContext _context;

        public KudosController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Kudos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblKudos.ToListAsync());
        }

        // GET: Kudos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKudo = await _context.TblKudos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblKudo == null)
            {
                return NotFound();
            }

            return View(tblKudo);
        }

        // GET: Kudos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kudos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KudosToDisplayName,KudosToEmail,DateCreated,CreatedBy,CreatedByEmail,Note,Archived")] TblKudo tblKudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblKudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblKudo);
        }

        // GET: Kudos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKudo = await _context.TblKudos.FindAsync(id);
            if (tblKudo == null)
            {
                return NotFound();
            }
            return View(tblKudo);
        }

        // POST: Kudos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KudosToDisplayName,KudosToEmail,DateCreated,CreatedBy,CreatedByEmail,Note,Archived")] TblKudo tblKudo)
        {
            if (id != tblKudo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblKudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblKudoExists(tblKudo.Id))
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
            return View(tblKudo);
        }

        // GET: Kudos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKudo = await _context.TblKudos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblKudo == null)
            {
                return NotFound();
            }

            return View(tblKudo);
        }

        // POST: Kudos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblKudo = await _context.TblKudos.FindAsync(id);
            _context.TblKudos.Remove(tblKudo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblKudoExists(int id)
        {
            return _context.TblKudos.Any(e => e.Id == id);
        }
    }
}
