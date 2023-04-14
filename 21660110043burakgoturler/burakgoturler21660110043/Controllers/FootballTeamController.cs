using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using burakgoturler21660110043.Models;

namespace burakgoturler21660110043.Controllers
{
    public class FootballTeamController : Controller
    {
        private readonly FootballContext _context;

        public FootballTeamController( )
        {
            _context = new FootballContext();
        }

        // GET: FootballTeam
        public async Task<IActionResult> Index()
        {
              return _context.FootballTeams != null ? 
                          View(await _context.FootballTeams.ToListAsync()) :
                          Problem("Entity set 'FootballContext.FootballTeams'  is null.");
        }

        // GET: FootballTeam/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.FootballTeams == null)
            {
                return NotFound();
            }

            var footballTeam = await _context.FootballTeams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballTeam == null)
            {
                return NotFound();
            }

            return View(footballTeam);
        }

        // GET: FootballTeam/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FootballTeam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortName,EstablishDate,DirectorName,UniformTeamColor,DirectoHelperName")] FootballTeam footballTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footballTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footballTeam);
        }

        // GET: FootballTeam/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.FootballTeams == null)
            {
                return NotFound();
            }

            var footballTeam = await _context.FootballTeams.FindAsync(id);
            if (footballTeam == null)
            {
                return NotFound();
            }
            return View(footballTeam);
        }

        // POST: FootballTeam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,ShortName,EstablishDate,DirectorName,UniformTeamColor,DirectoHelperName")] FootballTeam footballTeam)
        {
            if (id != footballTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footballTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballTeamExists(footballTeam.Id))
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
            return View(footballTeam);
        }

        // GET: FootballTeam/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.FootballTeams == null)
            {
                return NotFound();
            }

            var footballTeam = await _context.FootballTeams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballTeam == null)
            {
                return NotFound();
            }

            return View(footballTeam);
        }

        // POST: FootballTeam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.FootballTeams == null)
            {
                return Problem("Entity set 'FootballContext.FootballTeams'  is null.");
            }
            var footballTeam = await _context.FootballTeams.FindAsync(id);
            if (footballTeam != null)
            {
                _context.FootballTeams.Remove(footballTeam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballTeamExists(long id)
        {
          return (_context.FootballTeams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
