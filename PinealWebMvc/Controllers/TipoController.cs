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
    public class TipoController : Controller
    {
        private readonly PinealWebMvcContext _context;

        public TipoController(PinealWebMvcContext context)
        {
            _context = context;
        }

        // GET: TipoProjetoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo.ToListAsync());
        }

        // GET: TipoProjetoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProjeto = await _context.Tipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoProjeto == null)
            {
                return NotFound();
            }

            return View(tipoProjeto);
        }

        // GET: TipoProjetoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoProjetoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Tipo tipoProjeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProjeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProjeto);
        }

        // GET: TipoProjetoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProjeto = await _context.Tipo.FindAsync(id);
            if (tipoProjeto == null)
            {
                return NotFound();
            }
            return View(tipoProjeto);
        }

        // POST: TipoProjetoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Tipo tipoProjeto)
        {
            if (id != tipoProjeto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProjeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProjetoExists(tipoProjeto.Id))
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
            return View(tipoProjeto);
        }

        // GET: TipoProjetoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProjeto = await _context.Tipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoProjeto == null)
            {
                return NotFound();
            }

            return View(tipoProjeto);
        }

        // POST: TipoProjetoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProjeto = await _context.Tipo.FindAsync(id);
            _context.Tipo.Remove(tipoProjeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProjetoExists(int id)
        {
            return _context.Tipo.Any(e => e.Id == id);
        }
    }
}
