using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Country.Data;
using Country.Models;

namespace Country.Controllers
{
    public class CountryAllController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryAllController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            IEnumerable<CountryAll> countryAlls =  _context.countries.ToList();

            return View(countryAlls);
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.countries == null)
            {
                return NotFound();
            }

            var countryAll = await _context.countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countryAll == null)
            {
                return NotFound();
            }

            return View(countryAll);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryAll countryAll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countryAll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countryAll);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.countries == null)
            {
                return NotFound();
            }

            var countryAll = await _context.countries.FindAsync(id);
            if (countryAll == null)
            {
                return NotFound();
            }
            return View(countryAll);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountryName,Population,NationalLangauge,NumberOfStates,Region")] CountryAll countryAll)
        {
            if (id != countryAll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryAll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryAllExists(countryAll.Id))
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
            return View(countryAll);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.countries == null)
            {
                return NotFound();
            }

            var countryAll = await _context.countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countryAll == null)
            {
                return NotFound();
            }

            return View(countryAll);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.countries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.countries'  is null.");
            }
            var countryAll = await _context.countries.FindAsync(id);
            if (countryAll != null)
            {
                _context.countries.Remove(countryAll);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryAllExists(int id)
        {
          return (_context.countries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
