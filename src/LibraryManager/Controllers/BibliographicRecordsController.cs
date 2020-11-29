using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Core;
using LibraryManager.Infrastructure.Data;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliographicRecordsController : ControllerBase
    {
        private readonly LibraryManagerDbContext context;

        public BibliographicRecordsController(LibraryManagerDbContext context)
        {
            this.context = context;
        }

        // GET: api/BibliographicRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BibliographicRecord>>> GetBibliographicRecords()
        {
            return await context.BibliographicRecords.ToListAsync();
        }

        // GET: api/BibliographicRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BibliographicRecord>> GetBibliographicRecord(int id)
        {
            var bibliographicRecord = await context.BibliographicRecords.FindAsync(id);

            if (bibliographicRecord == null)
            {
                return NotFound();
            }

            return bibliographicRecord;
        }

        // PUT: api/BibliographicRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBibliographicRecord(int id, BibliographicRecord bibliographicRecord)
        {
            if (id != bibliographicRecord.Id)
            {
                return BadRequest();
            }

            context.Entry(bibliographicRecord).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibliographicRecordExists(id))
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

        // POST: api/BibliographicRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BibliographicRecord>> PostBibliographicRecord(BibliographicRecord bibliographicRecord)
        {
            context.BibliographicRecords.Add(bibliographicRecord);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetBibliographicRecord", new { id = bibliographicRecord.Id }, bibliographicRecord);
        }

        // DELETE: api/BibliographicRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBibliographicRecord(int id)
        {
            var bibliographicRecord = await context.BibliographicRecords.FindAsync(id);
            if (bibliographicRecord == null)
            {
                return NotFound();
            }

            context.BibliographicRecords.Remove(bibliographicRecord);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool BibliographicRecordExists(int id)
        {
            return context.BibliographicRecords.Any(e => e.Id == id);
        }
    }
}
