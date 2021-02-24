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
    public class KudosEmailsController : Controller
    {
        private readonly ReviewContext _context;

        public KudosEmailsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: KudosEmails
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblKudosEmails.ToListAsync());
        }

        // GET: KudosEmails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKudosEmail = await _context.TblKudosEmails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblKudosEmail == null)
            {
                return NotFound();
            }

            return View(tblKudosEmail);
        }

        // GET: KudosEmails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KudosEmails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,From,Subject,Cc,Body,DateTimeReceived,AttachmentFileName,Archived")] TblKudosEmail tblKudosEmail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblKudosEmail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblKudosEmail);
        }

        // GET: KudosEmails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKudosEmail = await _context.TblKudosEmails.FindAsync(id);
            if (tblKudosEmail == null)
            {
                return NotFound();
            }
            return View(tblKudosEmail);
        }

        // POST: KudosEmails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,From,Subject,Cc,Body,DateTimeReceived,AttachmentFileName,Archived")] TblKudosEmail tblKudosEmail)
        {
            if (id != tblKudosEmail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblKudosEmail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblKudosEmailExists(tblKudosEmail.Id))
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
            return View(tblKudosEmail);
        }

        // GET: KudosEmails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKudosEmail = await _context.TblKudosEmails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblKudosEmail == null)
            {
                return NotFound();
            }

            return View(tblKudosEmail);
        }

        // POST: KudosEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblKudosEmail = await _context.TblKudosEmails.FindAsync(id);
            _context.TblKudosEmails.Remove(tblKudosEmail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblKudosEmailExists(int id)
        {
            return _context.TblKudosEmails.Any(e => e.Id == id);
        }
    }
}
