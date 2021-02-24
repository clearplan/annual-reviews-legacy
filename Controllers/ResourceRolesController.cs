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
    public class ResourceRolesController : Controller
    {
        private readonly ReviewContext _context;

        public ResourceRolesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: ResourceRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResourceRoles.ToListAsync());
        }

        // GET: ResourceRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResourceRole = await _context.TblResourceRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResourceRole == null)
            {
                return NotFound();
            }

            return View(tblResourceRole);
        }

        // GET: ResourceRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResourceRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Role")] TblResourceRole tblResourceRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResourceRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResourceRole);
        }

        // GET: ResourceRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResourceRole = await _context.TblResourceRoles.FindAsync(id);
            if (tblResourceRole == null)
            {
                return NotFound();
            }
            return View(tblResourceRole);
        }

        // POST: ResourceRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Role")] TblResourceRole tblResourceRole)
        {
            if (id != tblResourceRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResourceRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResourceRoleExists(tblResourceRole.Id))
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
            return View(tblResourceRole);
        }

        // GET: ResourceRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResourceRole = await _context.TblResourceRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResourceRole == null)
            {
                return NotFound();
            }

            return View(tblResourceRole);
        }

        // POST: ResourceRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResourceRole = await _context.TblResourceRoles.FindAsync(id);
            _context.TblResourceRoles.Remove(tblResourceRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResourceRoleExists(int id)
        {
            return _context.TblResourceRoles.Any(e => e.Id == id);
        }
    }
}
