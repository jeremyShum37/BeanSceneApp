using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSceneApp.Data;
using BeanSceneApp.Models;

namespace BeanSceneApp.Controllers
{
    public class TablesController : Controller
    {
        private readonly BeanSceneAppContext _context;

        public TablesController(BeanSceneAppContext context)
        {
            _context = context;
        }

        // GET: Tables
        public async Task<IActionResult> Index()
        {
            var beanSceneAppContext = _context.Table.Include(t => t.Area).Include(t => t.Reservation);
            return View(await beanSceneAppContext.ToListAsync());
        }

        // GET: Tables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .Include(t => t.Area)
                .Include(t => t.Reservation)
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // GET: Tables/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaName");
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "ReservationId", "GuestName");
            return View();
        }

        // POST: Tables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TableId,TableNumber,Capacity,AreaId,ReservationId")] Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaName", table.AreaId);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "ReservationId", "GuestName", table.ReservationId);
            return View(table);
        }

        // GET: Tables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaName", table.AreaId);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "ReservationId", "GuestName", table.ReservationId);
            return View(table);
        }

        // POST: Tables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TableId,TableNumber,Capacity,AreaId,ReservationId")] Table table)
        {
            if (id != table.TableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableExists(table.TableId))
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
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaName", table.AreaId);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "ReservationId", "GuestName", table.ReservationId);
            return View(table);
        }

        // GET: Tables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .Include(t => t.Area)
                .Include(t => t.Reservation)
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // POST: Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var table = await _context.Table.FindAsync(id);
            if (table != null)
            {
                _context.Table.Remove(table);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableExists(int id)
        {
            return _context.Table.Any(e => e.TableId == id);
        }
    }
}
