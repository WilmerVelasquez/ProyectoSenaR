using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecursosHumanos.Data;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers
{
    [Authorize]
    public class RegistroIngresoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroIngresoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroIngreso
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistroIngresos.ToListAsync());
        }

        // GET: RegistroIngreso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroIngreso = await _context.RegistroIngresos
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registroIngreso == null)
            {
                return NotFound();
            }

            return View(registroIngreso);
        }

        // GET: RegistroIngreso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroIngreso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistro,NombreRegistro,FechaEntrada,FechaSalida,IdUsuario,IdHorario")] RegistroIngreso registroIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroIngreso);
        }

        // GET: RegistroIngreso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroIngreso = await _context.RegistroIngresos.FindAsync(id);
            if (registroIngreso == null)
            {
                return NotFound();
            }
            return View(registroIngreso);
        }

        // POST: RegistroIngreso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistro,NombreRegistro,FechaEntrada,FechaSalida,IdUsuario,IdHorario")] RegistroIngreso registroIngreso)
        {
            if (id != registroIngreso.IdRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroIngresoExists(registroIngreso.IdRegistro))
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
            return View(registroIngreso);
        }

        // GET: RegistroIngreso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroIngreso = await _context.RegistroIngresos
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registroIngreso == null)
            {
                return NotFound();
            }

            return View(registroIngreso);
        }

        // POST: RegistroIngreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroIngreso = await _context.RegistroIngresos.FindAsync(id);
            _context.RegistroIngresos.Remove(registroIngreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroIngresoExists(int id)
        {
            return _context.RegistroIngresos.Any(e => e.IdRegistro == id);
        }
    }
}
