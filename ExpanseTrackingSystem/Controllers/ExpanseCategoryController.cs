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
    public class ExpanseCategoryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ExpanseCategoryController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: ExpanseCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpanseCategories.ToListAsync());
        }

        // GET: ExpanseCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expanseCategory = await _context.ExpanseCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expanseCategory == null)
            {
                return NotFound();
            }

            return View(expanseCategory);
        }

        // GET: ExpanseCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpanseCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName,Details")] ExpanseCategory expanseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expanseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expanseCategory);
        }

        // GET: ExpanseCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var expanseCategory = await _context.ExpanseCategories.FindAsync(id);
            if (expanseCategory == null)
            {
                return NotFound();
            }
            return View(expanseCategory);
        }

        // POST: ExpanseCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,Details")] ExpanseCategory expanseCategory)
        {
            if (id != expanseCategory.Id)
            {
                return NotFound();
            }
            if (IsExists(expanseCategory.Id, expanseCategory.CategoryName))
            {
                ModelState.AddModelError("CategoryName", "Category Name already exist.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expanseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpanseCategoryExists(expanseCategory.Id))
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
            return View(expanseCategory);
        }

        // GET: ExpanseCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expanseCategory = await _context.ExpanseCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expanseCategory == null)
            {
                return NotFound();
            }

            return View(expanseCategory);
        }

        // POST: ExpanseCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expanseCategory = await _context.ExpanseCategories.FindAsync(id);
            _context.ExpanseCategories.Remove(expanseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpanseCategoryExists(int id)
        {
            return _context.ExpanseCategories.Any(e => e.Id == id);
        }
        private bool IsExists(int id, string name)
        {
            return _context.ExpanseCategories.Any(e => e.CategoryName == name && e.Id != id);
        }
    }
}
