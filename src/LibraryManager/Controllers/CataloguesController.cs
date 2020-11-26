using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Core;
using LibraryManager.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CataloguesController : ControllerBase
    {
        private readonly LibraryManagerDbContext context;
        private readonly ILogger<CataloguesController> logger;

        public CataloguesController(LibraryManagerDbContext context, ILogger<CataloguesController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET: api/Catalogues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalogue>>> GetCatalogues()
        {
            logger.LogInformation("GetCatalogues");
            return await context.Catalogues.ToListAsync();
        }

        // GET: api/Catalogues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catalogue>> GetCatalogue(int id)
        {
            logger.LogInformation("GetCatalogue");
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
            logger.LogInformation("PutCatalogue");
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
            logger.LogInformation("PostCatalogue");
            context.Catalogues.Add(catalogue);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogue", new { id = catalogue.Id }, catalogue);
        }

        // DELETE: api/Catalogues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogue(int id)
        {
            logger.LogInformation("DeleteCatalogue");
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
