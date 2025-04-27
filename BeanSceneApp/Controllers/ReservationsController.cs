using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSceneApp.Data;
using BeanSceneApp.Models;
using BeanSceneApp.Services;

namespace BeanSceneApp.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly BeanSceneAppContext _context;
        private InterReservService IRService;
        private AbstrReservService ARService;

        public ReservationsController(BeanSceneAppContext context, InterReservService IRS, AbstrReservService ARS)
        {
            _context = context;
            IRService = IRS;
            ARService = ARS;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var beanSceneAppContext = _context.Reservations.Include(r => r.Member).Include(r => r.Sitting);
            return View(await beanSceneAppContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Member)
                .Include(r => r.Sitting)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Member, "UserId", "Email");
            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingType");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,GuestName,Email,Phone,StartTime,Duration,GuestCount,Status,Source,Notes,SittingId,MemberId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var result = IRService.CreateReservation(reservation);
                if (result != null) 
                //_context.Add(reservation);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Member, "UserId", "Email", reservation.MemberId);
            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingType", reservation.SittingId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Member, "UserId", "Email", reservation.MemberId);
            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingType", reservation.SittingId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,GuestName,Email,Phone,StartTime,Duration,GuestCount,Status,Source,Notes,SittingId,MemberId")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = ARService.EditReservation(reservation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
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
            ViewData["MemberId"] = new SelectList(_context.Member, "UserId", "Email", reservation.MemberId);
            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingType", reservation.SittingId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Member)
                .Include(r => r.Sitting)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }
    }
}
