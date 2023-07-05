using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst_empAPP.Models;

namespace CodeFirst_empAPP.Controllers
{
    public class employeesController : Controller
    {
        private readonly empDBContext _context;

        public employeesController(empDBContext context)
        {
            _context = context;
        }

        // GET: employees
        public async Task<IActionResult> Index()
        {
              return _context.empDetails != null ? 
                          View(await _context.empDetails.ToListAsync()) :
                          Problem("Entity set 'empDBContext.empDetails'  is null.");
        }

        // GET: employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.empDetails == null)
            {
                return NotFound();
            }

            var employeeDetails = await _context.empDetails
                .FirstOrDefaultAsync(m => m.empNo == id);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            return View(employeeDetails);
        }

        // GET: employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empNo,empName,empSalary,empCity,empIsPermenant")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDetails);
        }

        // GET: employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.empDetails == null)
            {
                return NotFound();
            }

            var employeeDetails = await _context.empDetails.FindAsync(id);
            if (employeeDetails == null)
            {
                return NotFound();
            }
            return View(employeeDetails);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empNo,empName,empSalary,empCity,empIsPermenant")] EmployeeDetails employeeDetails)
        {
            if (id != employeeDetails.empNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDetailsExists(employeeDetails.empNo))
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
            return View(employeeDetails);
        }

        // GET: employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.empDetails == null)
            {
                return NotFound();
            }

            var employeeDetails = await _context.empDetails
                .FirstOrDefaultAsync(m => m.empNo == id);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            return View(employeeDetails);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.empDetails == null)
            {
                return Problem("Entity set 'empDBContext.empDetails'  is null.");
            }
            var employeeDetails = await _context.empDetails.FindAsync(id);
            if (employeeDetails != null)
            {
                _context.empDetails.Remove(employeeDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDetailsExists(int id)
        {
          return (_context.empDetails?.Any(e => e.empNo == id)).GetValueOrDefault();
        }
    }
}
