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
    public class VentasController : Controller
    {
        private readonly AlmacenContext _context;

        public VentasController(AlmacenContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index(string nombre)
        {
            var filter = _context.Ventas.Where(s => s.Clientes.Nombre.Contains(nombre));
            if (nombre != null)
            {
                return View(filter);
            }
            else
            {
                var almacenContext = _context.Ventas.Include(v => v.Clientes).Include(v => v.Empleado).Include(v => v.Productos);
                return View(await almacenContext.ToListAsync());
            }

        }

        // GET: Ventas/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .Include(v => v.Clientes)
                .Include(v => v.Empleado)
                .Include(v => v.Productos)
                .FirstOrDefaultAsync(m => m.VentasID == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClientesID"] = new SelectList(_context.Clientes, "CLientesID", "Nombre");
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "EmpleadosID", "Nombre");
            ViewData["ProductosID"] = new SelectList(_context.Productos, "ProductosID", "PaisOrigen");
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentasID,EmpleadoID,ClientesID,ProductosID,DateTime")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                ventas.DateTime = DateTime.Now;
                _context.Add(ventas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesID"] = new SelectList(_context.Clientes, "CLientesID", "Nombre", ventas.ClientesID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "EmpleadosID", "Nombre", ventas.EmpleadoID);
            ViewData["ProductosID"] = new SelectList(_context.Productos, "ProductosID", "PaisOrigen", ventas.ProductosID);
            return View(ventas);
        }

        // GET: Ventas/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }
            ViewData["ClientesID"] = new SelectList(_context.Clientes, "CLientesID", "Nombre", ventas.ClientesID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "EmpleadosID", "Nombre", ventas.EmpleadoID);
            ViewData["ProductosID"] = new SelectList(_context.Productos, "ProductosID", "PaisOrigen", ventas.ProductosID);
            return View(ventas);
        }

        // POST: Ventas/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentasID,EmpleadoID,ClientesID,ProductosID,DateTime")] Ventas ventas)
        {
            if (id != ventas.VentasID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasExists(ventas.VentasID))
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
            ViewData["ClientesID"] = new SelectList(_context.Clientes, "CLientesID", "Nombre", ventas.ClientesID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleados, "EmpleadosID", "Nombre", ventas.EmpleadoID);
            ViewData["ProductosID"] = new SelectList(_context.Productos, "ProductosID", "PaisOrigen", ventas.ProductosID);
            return View(ventas);
        }

        // GET: Ventas/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .Include(v => v.Clientes)
                .Include(v => v.Empleado)
                .Include(v => v.Productos)
                .FirstOrDefaultAsync(m => m.VentasID == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // POST: Ventas/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventas = await _context.Ventas.FindAsync(id);
            _context.Ventas.Remove(ventas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasExists(int id)
        {
            return _context.Ventas.Any(e => e.VentasID == id);
        }
    }
}
