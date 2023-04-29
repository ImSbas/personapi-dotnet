﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    public class ProfesiónController : Controller
    {
        private readonly PersonaDbContext _context;

        public ProfesiónController(PersonaDbContext context)
        {
            _context = context;
        }

        // GET: Profesión
        public async Task<IActionResult> Index()
        {
              return _context.Profesións != null ? 
                          View(await _context.Profesións.ToListAsync()) :
                          Problem("Entity set 'PersonaDbContext.Profesións'  is null.");
        }

        // GET: Profesión/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profesións == null)
            {
                return NotFound();
            }

            var profesión = await _context.Profesións
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesión == null)
            {
                return NotFound();
            }

            return View(profesión);
        }

        // GET: Profesión/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesión/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Des")] Profesión profesión)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesión);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesión);
        }

        // GET: Profesión/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profesións == null)
            {
                return NotFound();
            }

            var profesión = await _context.Profesións.FindAsync(id);
            if (profesión == null)
            {
                return NotFound();
            }
            return View(profesión);
        }

        // POST: Profesión/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Des")] Profesión profesión)
        {
            if (id != profesión.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesión);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesiónExists(profesión.Id))
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
            return View(profesión);
        }

        // GET: Profesión/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profesións == null)
            {
                return NotFound();
            }

            var profesión = await _context.Profesións
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesión == null)
            {
                return NotFound();
            }

            return View(profesión);
        }

        // POST: Profesión/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profesións == null)
            {
                return Problem("Entity set 'PersonaDbContext.Profesións'  is null.");
            }
            var profesión = await _context.Profesións.FindAsync(id);
            if (profesión != null)
            {
                _context.Profesións.Remove(profesión);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesiónExists(int id)
        {
          return (_context.Profesións?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
