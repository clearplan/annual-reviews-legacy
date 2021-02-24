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
    public class ResourcesController : Controller
    {
        private readonly ReviewContext _context;

        public ResourcesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Resources
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblResources.ToListAsync());
        }

        // GET: Resources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResource = await _context.TblResources
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResource == null)
            {
                return NotFound();
            }

            return View(tblResource);
        }

        // GET: Resources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResourceId,LastName,MiddleName,FirstName,FullName,Suffix,DepartmentId,Image,Email,Phone,StatusId,StartDate,EndDate,ReportsToId,RoleId")] TblResource tblResource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblResource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblResource);
        }

        // GET: Resources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResource = await _context.TblResources.FindAsync(id);
            if (tblResource == null)
            {
                return NotFound();
            }
            return View(tblResource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResourceId,LastName,MiddleName,FirstName,FullName,Suffix,DepartmentId,Image,Email,Phone,StatusId,StartDate,EndDate,ReportsToId,RoleId")] TblResource tblResource)
        {
            if (id != tblResource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblResource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblResourceExists(tblResource.Id))
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
            return View(tblResource);
        }

        // GET: Resources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblResource = await _context.TblResources
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblResource == null)
            {
                return NotFound();
            }

            return View(tblResource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblResource = await _context.TblResources.FindAsync(id);
            _context.TblResources.Remove(tblResource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblResourceExists(int id)
        {
            return _context.TblResources.Any(e => e.Id == id);
        }
    }
}
