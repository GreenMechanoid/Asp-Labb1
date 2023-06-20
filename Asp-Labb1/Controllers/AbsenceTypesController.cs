using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp_Labb1.Data;
using Asp_Labb1.Models;

namespace Asp_Labb1.Controllers
{
    public class AbsenceTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbsenceTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AbsenceTypes
        public async Task<IActionResult> Index()
        {
              return _context.AbsenceType != null ? 
                          View(await _context.AbsenceType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AbsenceType'  is null.");
        }

        // GET: AbsenceTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AbsenceType == null)
            {
                return NotFound();
            }

            var absenceType = await _context.AbsenceType
                .FirstOrDefaultAsync(m => m.AbsenceTypeID == id);
            if (absenceType == null)
            {
                return NotFound();
            }

            return View(absenceType);
        }

        // GET: AbsenceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AbsenceTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AbsenceTypeID,TypeOfAbsence")] AbsenceType absenceType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absenceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(absenceType);
        }

        // GET: AbsenceTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AbsenceType == null)
            {
                return NotFound();
            }

            var absenceType = await _context.AbsenceType.FindAsync(id);
            if (absenceType == null)
            {
                return NotFound();
            }
            return View(absenceType);
        }

        // POST: AbsenceTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AbsenceTypeID,TypeOfAbsence")] AbsenceType absenceType)
        {
            if (id != absenceType.AbsenceTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absenceType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsenceTypeExists(absenceType.AbsenceTypeID))
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
            return View(absenceType);
        }

        // GET: AbsenceTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AbsenceType == null)
            {
                return NotFound();
            }

            var absenceType = await _context.AbsenceType
                .FirstOrDefaultAsync(m => m.AbsenceTypeID == id);
            if (absenceType == null)
            {
                return NotFound();
            }

            return View(absenceType);
        }

        // POST: AbsenceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AbsenceType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AbsenceType'  is null.");
            }
            var absenceType = await _context.AbsenceType.FindAsync(id);
            if (absenceType != null)
            {
                _context.AbsenceType.Remove(absenceType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceTypeExists(int id)
        {
          return (_context.AbsenceType?.Any(e => e.AbsenceTypeID == id)).GetValueOrDefault();
        }
    }
}
