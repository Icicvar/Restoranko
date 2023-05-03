﻿using System;
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
    public class TablesController : ControllerBase
    {
        private readonly RestorankoDbContext _context;

        public TablesController(RestorankoDbContext context)
        {
            _context = context;
        }

        // GET: api/Tables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
          if (_context.Tables == null)
          {
              return NotFound();
          }
            return await _context.Tables.ToListAsync();
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
          if (_context.Tables == null)
          {
              return NotFound();
          }
            var table = await _context.Tables.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }

        // PUT: api/Tables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(int id, Table table)
        {
            if (id != table.Idtable)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
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

        // POST: api/Tables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(Table table)
        {
          if (_context.Tables == null)
          {
              return Problem("Entity set 'RestorankoDbContext.Tables'  is null.");
          }
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTable", new { id = table.Idtable }, table);
        }

        // DELETE: api/Tables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            if (_context.Tables == null)
            {
                return NotFound();
            }
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableExists(int id)
        {
            return (_context.Tables?.Any(e => e.Idtable == id)).GetValueOrDefault();
        }
    }
}
