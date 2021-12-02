using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpanseTrackingSystem.Context;

namespace ExpanseTrackingSystem.Controllers
{
    public class ExpanseController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ExpanseController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Expanse
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Expanses.Include(e => e.ExpanseCategory);
            return View(await applicationDBContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> SearchResult(DateTime? fromDate, DateTime? toDate)
        {
            var applicationDBContext = _context.Expanses.Include(e => e.ExpanseCategory).Where(f => (fromDate == null || f.EntryDate >= fromDate) && (toDate == null || f.EntryDate <= toDate));
            return PartialView(await applicationDBContext.ToListAsync());
        }

        // GET: Expanse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expanse = await _context.Expanses
                .Include(e => e.ExpanseCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expanse == null)
            {
                return NotFound();
            }

            return View(expanse);
        }

        // GET: Expanse/Create
        public IActionResult Create()
        {
            ViewData["ExpanseCategoryId"] = new SelectList(_context.ExpanseCategories, "Id", "CategoryName");
            return View();
        }

        // POST: Expanse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExpanseCategoryId,EntryDate,ExpanseAmount,Details")] Expanse expanse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expanse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpanseCategoryId"] = new SelectList(_context.ExpanseCategories, "Id", "CategoryName", expanse.ExpanseCategoryId);
            return View(expanse);
        }

        // GET: Expanse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expanse = await _context.Expanses.FindAsync(id);
            if (expanse == null)
            {
                return NotFound();
            }
            ViewData["ExpanseCategoryId"] = new SelectList(_context.ExpanseCategories, "Id", "CategoryName", expanse.ExpanseCategoryId);
            return View(expanse);
        }

        // POST: Expanse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExpanseCategoryId,EntryDate,ExpanseAmount,Details")] Expanse expanse)
        {
            if (id != expanse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expanse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpanseExists(expanse.Id))
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
            ViewData["ExpanseCategoryId"] = new SelectList(_context.ExpanseCategories, "Id", "CategoryName", expanse.ExpanseCategoryId);
            return View(expanse);
        }

        // GET: Expanse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expanse = await _context.Expanses
                .Include(e => e.ExpanseCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expanse == null)
            {
                return NotFound();
            }

            return View(expanse);
        }

        // POST: Expanse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expanse = await _context.Expanses.FindAsync(id);
            _context.Expanses.Remove(expanse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpanseExists(int id)
        {
            return _context.Expanses.Any(e => e.Id == id);
        }
    }
}
