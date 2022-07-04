using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PinealWebMvc.Data;
using PinealWebMvc.Models;

namespace PinealWebMvc.Controllers
{
    public class VertentesController : Controller
    {
        private readonly PinealWebMvcContext _context;

        public VertentesController(PinealWebMvcContext context)
        {
            _context = context;
        }

        // GET: Vertentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vertente.ToListAsync());
        }

        // GET: Vertentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vertente = await _context.Vertente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vertente == null)
            {
                return NotFound();
            }

            return View(vertente);
        }

        // GET: Vertentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vertentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Vertente vertente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vertente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vertente);
        }

        // GET: Vertentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vertente = await _context.Vertente.FindAsync(id);
            if (vertente == null)
            {
                return NotFound();
            }
            return View(vertente);
        }

        // POST: Vertentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Vertente vertente)
        {
            if (id != vertente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vertente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VertenteExists(vertente.Id))
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
            return View(vertente);
        }

        // GET: Vertentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vertente = await _context.Vertente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vertente == null)
            {
                return NotFound();
            }

            return View(vertente);
        }

        // POST: Vertentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vertente = await _context.Vertente.FindAsync(id);
            _context.Vertente.Remove(vertente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VertenteExists(int id)
        {
            return _context.Vertente.Any(e => e.Id == id);
        }
    }
}
