using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypesController : ControllerBase
    {
        private readonly RestorankoDbContext _context;

        public JobTypesController(RestorankoDbContext context)
        {
            _context = context;
        }

        // GET: api/JobTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobType>>> GetJobTypes()
        {
          if (_context.JobTypes == null)
          {
              return NotFound();
          }
            return await _context.JobTypes.ToListAsync();
        }

        // GET: api/JobTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobType>> GetJobType(int id)
        {
          if (_context.JobTypes == null)
          {
              return NotFound();
          }
            var jobType = await _context.JobTypes.FindAsync(id);

            if (jobType == null)
            {
                return NotFound();
            }

            return jobType;
        }

        // PUT: api/JobTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobType(int id, JobType jobType)
        {
            if (id != jobType.IdjobType)
            {
                return BadRequest();
            }

            _context.Entry(jobType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTypeExists(id))
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

        // POST: api/JobTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobType>> PostJobType(JobType jobType)
        {
          if (_context.JobTypes == null)
          {
              return Problem("Entity set 'RestorankoDbContext.JobTypes'  is null.");
          }
            _context.JobTypes.Add(jobType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobType", new { id = jobType.IdjobType }, jobType);
        }

        // DELETE: api/JobTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobType(int id)
        {
            if (_context.JobTypes == null)
            {
                return NotFound();
            }
            var jobType = await _context.JobTypes.FindAsync(id);
            if (jobType == null)
            {
                return NotFound();
            }

            _context.JobTypes.Remove(jobType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobTypeExists(int id)
        {
            return (_context.JobTypes?.Any(e => e.IdjobType == id)).GetValueOrDefault();
        }
    }
}
