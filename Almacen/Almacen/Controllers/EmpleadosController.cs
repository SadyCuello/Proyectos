using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Almacen.Data;

namespace Almacen.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly AlmacenContext _context;

        public EmpleadosController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index(string nombre)
        {
            var filter = _context.Empleados.Where(s => s.Nombre.Contains(nombre));
            if (nombre != null)
            {
                return View(filter);
            }
            return View(await _context.Empleados.ToListAsync());
        }

        // GET: Empleados/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .FirstOrDefaultAsync(m => m.EmpleadosID == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadosID,Sueldo,Area,CantidadTrabajo,Nombre,Apellido,Edad,Direccion")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleados);
        }

        // GET: Empleados/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadosID,Sueldo,Area,CantidadTrabajo,Nombre,Apellido,Edad,Direccion")] Empleados empleados)
        {
            if (id != empleados.EmpleadosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.EmpleadosID))
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
            return View(empleados);
        }

        // GET: Empleados/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .FirstOrDefaultAsync(m => m.EmpleadosID == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            return _context.Empleados.Any(e => e.EmpleadosID == id);
        }
    }
}
