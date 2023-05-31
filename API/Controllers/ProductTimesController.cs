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
    public class ProductTimesController : ControllerBase
    {
        private readonly RestorankoDbUpdatedContext _context;

        public ProductTimesController(RestorankoDbUpdatedContext context)
        {
            _context = context;
        }

        // GET: api/ProductTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTime>>> GetProductTimes()
        {
          if (_context.ProductTimes == null)
          {
              return NotFound();
          }
            return await _context.ProductTimes.ToListAsync();
        }

        // GET: api/ProductTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTime>> GetProductTime(int id)
        {
          if (_context.ProductTimes == null)
          {
              return NotFound();
          }
            var productTime = await _context.ProductTimes.FindAsync(id);

            if (productTime == null)
            {
                return NotFound();
            }

            return productTime;
        }

        // PUT: api/ProductTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTime(int id, ProductTime productTime)
        {
            if (id != productTime.IdproductTime)
            {
                return BadRequest();
            }

            _context.Entry(productTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTimeExists(id))
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

        // POST: api/ProductTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTime>> PostProductTime(ProductTime productTime)
        {
          if (_context.ProductTimes == null)
          {
              return Problem("Entity set 'RestorankoDbUpdatedContext.ProductTimes'  is null.");
          }
            _context.ProductTimes.Add(productTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTime", new { id = productTime.IdproductTime }, productTime);
        }

        // DELETE: api/ProductTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTime(int id)
        {
            if (_context.ProductTimes == null)
            {
                return NotFound();
            }
            var productTime = await _context.ProductTimes.FindAsync(id);
            if (productTime == null)
            {
                return NotFound();
            }

            _context.ProductTimes.Remove(productTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTimeExists(int id)
        {
            return (_context.ProductTimes?.Any(e => e.IdproductTime == id)).GetValueOrDefault();
        }
    }
}
