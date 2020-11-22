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
    public class CataloguesController : ControllerBase
    {
        private readonly LibraryManagerDbContext context;

        public CataloguesController(LibraryManagerDbContext context)
        {
            this.context = context;
        }

        // GET: api/Catalogues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalogue>>> GetCatalogues()
        {
            return await context.Catalogues.ToListAsync();
        }

        // GET: api/Catalogues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catalogue>> GetCatalogue(int id)
        {
            var catalogue = await context.Catalogues.FindAsync(id);

            if (catalogue == null)
            {
                return NotFound();
            }

            return catalogue;
        }

        // PUT: api/Catalogues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogue(int id, Catalogue catalogue)
        {
            if (id != catalogue.Id)
            {
                return BadRequest();
            }

            context.Entry(catalogue).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogueExists(id))
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

        // POST: api/Catalogues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Catalogue>> PostCatalogue(Catalogue catalogue)
        {
            context.Catalogues.Add(catalogue);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogue", new { id = catalogue.Id }, catalogue);
        }

        // DELETE: api/Catalogues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogue(int id)
        {
            var catalogue = await context.Catalogues.FindAsync(id);
            if (catalogue == null)
            {
                return NotFound();
            }

            context.Catalogues.Remove(catalogue);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogueExists(int id)
        {
            return context.Catalogues.Any(e => e.Id == id);
        }
    }
}
