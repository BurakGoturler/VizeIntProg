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
    public class FootballPlayerController : Controller
    {
        private readonly FootballContext _context;

        public FootballPlayerController()
        {
            _context = new FootballContext();
        }

        // GET: FootballPlayer
        public async Task<IActionResult> Index()
        {
              return _context.FootballPlayers != null ? 
                          View(await _context.FootballPlayers.ToListAsync()) :
                          Problem("Entity set 'FootballContext.FootballPlayers'  is null.");
        }

        // GET: FootballPlayer/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.FootballPlayers == null)
            {
                return NotFound();
            }

            var footballPlayer = await _context.FootballPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballPlayer == null)
            {
                return NotFound();
            }

            return View(footballPlayer);
        }

        // GET: FootballPlayer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FootballPlayer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,BirthDate,Position,UniformNumber,RightOrHeftHanded")] FootballPlayer footballPlayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footballPlayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footballPlayer);
        }

        // GET: FootballPlayer/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.FootballPlayers == null)
            {
                return NotFound();
            }

            var footballPlayer = await _context.FootballPlayers.FindAsync(id);
            if (footballPlayer == null)
            {
                return NotFound();
            }
            return View(footballPlayer);
        }

        // POST: FootballPlayer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,LastName,BirthDate,Position,UniformNumber,RightOrHeftHanded")] FootballPlayer footballPlayer)
        {
            if (id != footballPlayer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footballPlayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballPlayerExists(footballPlayer.Id))
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
            return View(footballPlayer);
        }

        // GET: FootballPlayer/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.FootballPlayers == null)
            {
                return NotFound();
            }

            var footballPlayer = await _context.FootballPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballPlayer == null)
            {
                return NotFound();
            }

            return View(footballPlayer);
        }

        // POST: FootballPlayer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.FootballPlayers == null)
            {
                return Problem("Entity set 'FootballContext.FootballPlayers'  is null.");
            }
            var footballPlayer = await _context.FootballPlayers.FindAsync(id);
            if (footballPlayer != null)
            {
                _context.FootballPlayers.Remove(footballPlayer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballPlayerExists(long id)
        {
          return (_context.FootballPlayers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
