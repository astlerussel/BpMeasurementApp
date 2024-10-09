using BpMeasurementApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BpMeasurementApp.Controllers
{
    public class BpMeasurementController : Controller
    {

        private readonly BpMeasurementDbContext _context;

        public BpMeasurementController(BpMeasurementDbContext context)
        {
            _context = context;
        }
        // GET: All Measurements
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.LastActionMessage = TempData["LastActionMessage"] as string;
            var measurements =  _context.Measurements.Include(m => m.Position).ToList();
            return View(measurements);
        }

        // GET: Create Measurement
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Positions = new SelectList(_context.Positions, "ID", "Name");
            BpMeasurement measurement = new BpMeasurement();
            measurement.MeasurementDate = DateTime.Now;
            return View(measurement);
        }

        // POST: Create Measurement
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Systolic,Diastolic,PositionID,MeasurementDate")] BpMeasurement measurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measurement);
                 _context.SaveChanges();
                // Set a success message in TempData
                TempData["LastActionMessage"] = "Measurement added successfully!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Positions = new SelectList(_context.Positions, "ID", "Name", measurement.PositionID);
            return View(measurement);
        }

        // GET: Edit Measurement
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var measurement =  _context.Measurements.Find(id);
            if (measurement == null) return NotFound();

            ViewBag.Positions = new SelectList(_context.Positions, "ID", "Name", measurement.PositionID);
            return View(measurement);
        }

        // POST: Edit Measurement
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Systolic,Diastolic,MeasurementDate,PositionID")] BpMeasurement measurement)
        {
            if (id != measurement.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurement);
                     _context.SaveChanges();
                    // Set a success message in TempData
                    TempData["LastActionMessage"] = "Measurement updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasurementExists(measurement.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Positions = new SelectList(_context.Positions, "ID", "Name", measurement.PositionID);
            return View(measurement);
        }

        // GET: Delete Measurement
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var measurement =  _context.Measurements
                .Include(m => m.Position)
                .FirstOrDefault(m => m.Id == id);
            if (measurement == null) return NotFound();

            return View(measurement);
        }

        // POST: Delete Measurement
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var measurement =  _context.Measurements.Find(id);
            _context.Measurements.Remove(measurement);
             _context.SaveChanges();
            // Set a success message in TempData
            TempData["LastActionMessage"] = "Measurement deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurements.Any(e => e.Id == id);
        }

        public IActionResult InfoOnBP()
        {
            return View();
        }

    }
}
