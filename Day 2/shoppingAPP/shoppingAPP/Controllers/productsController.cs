using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shoppingAPP.Models.EF;

namespace shoppingAPP.Controllers
{
    public class productsController : Controller
    {
        private readonly NikhilShoppingappContext _context = new NikhilShoppingappContext();

        //public productsController(NikhilShoppingappContext context)
        //{
        //    _context = context;
        //}

        // GET: products
        public async Task<IActionResult> Index()
        {
              return _context.Productlists != null ? 
                          View(await _context.Productlists.ToListAsync()) :
                          Problem("Entity set 'NikhilShoppingappContext.Productlists'  is null.");
        }

        // GET: products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productlists == null)
            {
                return NotFound();
            }

            var productlist = await _context.Productlists
                .FirstOrDefaultAsync(m => m.PId == id);
            if (productlist == null)
            {
                return NotFound();
            }

            return View(productlist);
        }

        // GET: products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PId,PName,PCategory,PPrice,PIsInStock")] Productlist productlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productlist);
        }

        // GET: products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productlists == null)
            {
                return NotFound();
            }

            var productlist = await _context.Productlists.FindAsync(id);
            if (productlist == null)
            {
                return NotFound();
            }
            return View(productlist);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,PName,PCategory,PPrice,PIsInStock")] Productlist productlist)
        {
            if (id != productlist.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductlistExists(productlist.PId))
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
            return View(productlist);
        }

        // GET: products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productlists == null)
            {
                return NotFound();
            }

            var productlist = await _context.Productlists
                .FirstOrDefaultAsync(m => m.PId == id);
            if (productlist == null)
            {
                return NotFound();
            }

            return View(productlist);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productlists == null)
            {
                return Problem("Entity set 'NikhilShoppingappContext.Productlists'  is null.");
            }
            var productlist = await _context.Productlists.FindAsync(id);
            if (productlist != null)
            {
                _context.Productlists.Remove(productlist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductlistExists(int id)
        {
          return (_context.Productlists?.Any(e => e.PId == id)).GetValueOrDefault();
        }
    }
}
