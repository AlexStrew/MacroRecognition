using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RecognitionAPI.Models;

namespace RecognitionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckDetectionsController : ControllerBase
    {
        private readonly RecognitionDbContext _context;
        private readonly IConfiguration _configuration;


        public TruckDetectionsController(RecognitionDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }



        // GET: api/TruckDetections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TruckDetection>>> GetTruckDetections()
        {
          if (_context.TruckDetections == null)
          {
              return NotFound();
          }
            return await _context.TruckDetections.ToListAsync();
        }

        // GET: api/TruckDetections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TruckDetection>> GetTruckDetection(int id)
        {
          if (_context.TruckDetections == null)
          {
              return NotFound();
          }
            var truckDetection = await _context.TruckDetections.FindAsync(id);

            if (truckDetection == null)
            {
                return NotFound();
            }

            return truckDetection;
        }

        // PUT: api/TruckDetections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruckDetection(int id, TruckDetection truckDetection)
        {
            if (id != truckDetection.IdReco)
            {
                return BadRequest();
            }

            _context.Entry(truckDetection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckDetectionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TruckDetections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TruckDetection>> PostTruckDetection(TruckDetection truckDetection)
        {
          if (_context.TruckDetections == null)
          {
              return Problem("Entity set 'RecognitionDbContext.TruckDetections'  is null.");
          }
            _context.TruckDetections.Add(truckDetection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTruckDetection", new { id = truckDetection.IdReco }, truckDetection);
        }

        // DELETE: api/TruckDetections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruckDetection(int id)
        {
            if (_context.TruckDetections == null)
            {
                return NotFound();
            }
            var truckDetection = await _context.TruckDetections.FindAsync(id);
            if (truckDetection == null)
            {
                return NotFound();
            }

            _context.TruckDetections.Remove(truckDetection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TruckDetectionExists(int id)
        {
            return (_context.TruckDetections?.Any(e => e.IdReco == id)).GetValueOrDefault();
        }
    }
}
