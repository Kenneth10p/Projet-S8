﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestS8.Data;
using TestS8.Models;

namespace TestS8.Controllers
{
    public class PlotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plots
        public async Task<IActionResult> Index()
        {
              return _context.Plot != null ? 
                          View(await _context.Plot.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Plot'  is null.");
        }

        // GET: Plots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plot == null)
            {
                return NotFound();
            }

            var plot = await _context.Plot
                .FirstOrDefaultAsync(m => m.IdPlot == id);
            if (plot == null)
            {
                return NotFound();
            }

            return View(plot);
        }

        // GET: Plots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlot,Chemin")] Plot plot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plot);
        }

        // GET: Plots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plot == null)
            {
                return NotFound();
            }

            var plot = await _context.Plot.FindAsync(id);
            if (plot == null)
            {
                return NotFound();
            }
            return View(plot);
        }

        // POST: Plots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlot,Chemin")] Plot plot)
        {
            if (id != plot.IdPlot)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlotExists(plot.IdPlot))
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
            return View(plot);
        }

        // GET: Plots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plot == null)
            {
                return NotFound();
            }

            var plot = await _context.Plot
                .FirstOrDefaultAsync(m => m.IdPlot == id);
            if (plot == null)
            {
                return NotFound();
            }

            return View(plot);
        }

        // POST: Plots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plot == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Plot'  is null.");
            }
            var plot = await _context.Plot.FindAsync(id);
            if (plot != null)
            {
                _context.Plot.Remove(plot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlotExists(int id)
        {
          return (_context.Plot?.Any(e => e.IdPlot == id)).GetValueOrDefault();
        }
    }
}
