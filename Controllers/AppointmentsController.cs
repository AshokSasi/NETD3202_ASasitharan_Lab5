using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETD3202_ASasitharan_Lab5.Models;

namespace NETD3202_ASasitharan_Lab5.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HospitalContext _context;

        public AppointmentsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.appointment.Include(a => a.Doctor).Include(a => a.Patient);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.appointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["doctorId"] = new SelectList(_context.doctors, "doctorId", "doctorId");
            ViewData["patientId"] = new SelectList(_context.patients, "patientId", "patientId");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("appointmentId,appointmentType,appointmentDate,doctorId,patientId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["doctorId"] = new SelectList(_context.doctors, "doctorId", "doctorId", appointment.doctorId);
            ViewData["patientId"] = new SelectList(_context.patients, "patientId", "patientId", appointment.patientId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["doctorId"] = new SelectList(_context.doctors, "doctorId", "doctorId", appointment.doctorId);
            ViewData["patientId"] = new SelectList(_context.patients, "patientId", "patientId", appointment.patientId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("appointmentId,appointmentType,appointmentDate,doctorId,patientId")] Appointment appointment)
        {
            if (id != appointment.appointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.appointmentId))
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
            ViewData["doctorId"] = new SelectList(_context.doctors, "doctorId", "doctorId", appointment.doctorId);
            ViewData["patientId"] = new SelectList(_context.patients, "patientId", "patientId", appointment.patientId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.appointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.appointment.FindAsync(id);
            _context.appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.appointment.Any(e => e.appointmentId == id);
        }
    }
}
