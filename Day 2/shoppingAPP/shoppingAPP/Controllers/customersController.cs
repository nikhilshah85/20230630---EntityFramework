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
    public class customersController : Controller
    {
        private readonly NikhilShoppingappContext _context = new NikhilShoppingappContext();

        //public customersController(NikhilShoppingappContext context)
        //{
        //    _context = context;
        //}

        // GET: customers
        public async Task<IActionResult> Index()
        {
              return _context.CustomersLists != null ? 
                          View(await _context.CustomersLists.ToListAsync()) :
                          Problem("Entity set 'NikhilShoppingappContext.CustomersLists'  is null.");
        }

        // GET: customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomersLists == null)
            {
                return NotFound();
            }

            var customersList = await _context.CustomersLists
                .FirstOrDefaultAsync(m => m.CId == id);
            if (customersList == null)
            {
                return NotFound();
            }

            return View(customersList);
        }

        // GET: customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CId,CName,CCity,CWalletBalance,CIsActive")] CustomersList customersList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customersList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customersList);
        }

        // GET: customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomersLists == null)
            {
                return NotFound();
            }

            var customersList = await _context.CustomersLists.FindAsync(id);
            if (customersList == null)
            {
                return NotFound();
            }
            return View(customersList);
        }

        // POST: customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CId,CName,CCity,CWalletBalance,CIsActive")] CustomersList customersList)
        {
            if (id != customersList.CId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customersList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersListExists(customersList.CId))
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
            return View(customersList);
        }

        // GET: customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomersLists == null)
            {
                return NotFound();
            }

            var customersList = await _context.CustomersLists
                .FirstOrDefaultAsync(m => m.CId == id);
            if (customersList == null)
            {
                return NotFound();
            }

            return View(customersList);
        }

        // POST: customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomersLists == null)
            {
                return Problem("Entity set 'NikhilShoppingappContext.CustomersLists'  is null.");
            }
            var customersList = await _context.CustomersLists.FindAsync(id);
            if (customersList != null)
            {
                _context.CustomersLists.Remove(customersList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersListExists(int id)
        {
          return (_context.CustomersLists?.Any(e => e.CId == id)).GetValueOrDefault();
        }
    }
}
