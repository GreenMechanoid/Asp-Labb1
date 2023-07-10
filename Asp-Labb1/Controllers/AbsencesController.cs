using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp_Labb1.Data;
using Asp_Labb1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Asp_Labb1.Controllers
{
    public class AbsencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbsencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Absences by name
        public async Task<IActionResult> Index(string queryString)
        {
            var applicationDbContext = _context.Absence.Include(a => a.Employees);

            if (!string.IsNullOrEmpty(queryString))
            {
                return View("Index", await applicationDbContext.Where(emp => emp.Employees.FirstName.Contains(queryString)).ToListAsync());
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Absences search by start of abscence request month
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> SearchByMonth(DateTime? ByMonth)
        {
            var absenceList = from abs in _context.Absence
                              where (!ByMonth.HasValue || (abs.EndOfAbsence.Year == ByMonth.Value.Year && abs.EndOfAbsence.Month == ByMonth.Value.Month))
                              select abs;

            return View(await absenceList.Include(emp => emp.Employees).Include(ab => ab.Absencetypes).ToListAsync());
        }

        // GET: Absences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Absence == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence
                .Include(a => a.Employees)
                .Include(abs => abs.Absencetypes)
                .FirstOrDefaultAsync(m => m.AbsenceID == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // GET: Absences/Create
        public IActionResult Create()
        {
            ViewData["FK_EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "FirstName");
            ViewData["FK_AbsenceTypeID"] = new SelectList(_context.AbsenceType, "AbsenceTypeID", "TypeOfAbsence");
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AbsenceID,FK_AbsenceTypeID,FK_EmployeeID,StartOfAbsence,EndOfAbsence")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                absence.TimeCreated = DateTime.Now;
                _context.Add(absence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "FirstName", absence.FK_EmployeeID);
            ViewData["FK_AbsenceTypeID"] = new SelectList(_context.AbsenceType, "AbsenceTypeID", "TypeOfAbsence", absence.FK_AbsenceTypeID);
            return View(absence);
        }

        // GET: Absences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Absence == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence.FindAsync(id);
            if (absence == null)
            {
                return NotFound();
            }
            ViewData["FK_EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "FirstName", absence.FK_EmployeeID);
            ViewData["FK_AbsenceTypeID"] = new SelectList(_context.AbsenceType, "AbsenceTypeID", "TypeOfAbsence", absence.FK_AbsenceTypeID);
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AbsenceID,FK_AbsenceTypeID,FK_EmployeeID,StartOfAbsence,EndOfAbsence")] Absence absence)
        {
            if (id != absence.AbsenceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsenceExists(absence.AbsenceID))
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
            ViewData["FK_EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "FirstName", absence.FK_EmployeeID);
            ViewData["FK_AbsenceTypeID"] = new SelectList(_context.AbsenceType, "AbsenceTypeID", "TypeOfAbsence", absence.FK_AbsenceTypeID);
            return View(absence);
        }

        // GET: Absences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Absence == null)
            {
                return NotFound();
            }

            var absence = await _context.Absence
                .Include(a => a.Employees)
                .Include(abs => abs.Absencetypes)
                .FirstOrDefaultAsync(m => m.AbsenceID == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Absence == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Absence'  is null.");
            }
            var absence = await _context.Absence.FindAsync(id);
            if (absence != null)
            {
                _context.Absence.Remove(absence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceExists(int id)
        {
          return (_context.Absence?.Any(e => e.AbsenceID == id)).GetValueOrDefault();
        }
    }
}
