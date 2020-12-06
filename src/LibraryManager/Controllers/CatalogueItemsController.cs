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
    public class CatalogueItemsController : ControllerBase
    {
        private readonly LibraryManagerDbContext context;

        public CatalogueItemsController(LibraryManagerDbContext context)
        {
            this.context = context;
        }

        // GET: api/CatalogueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogueItem>>> GetCatalogueItems()
        {
            return await context.CatalogueItems.ToListAsync();
        }

        // GET: api/CatalogueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogueItem>> GetCatalogueItem(int id)
        {
            var catalogueItem = await context.CatalogueItems.FindAsync(id);

            if (catalogueItem == null)
            {
                return NotFound();
            }

            return catalogueItem;
        }

        // PUT: api/CatalogueItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogueItem(int id, CatalogueItem catalogueItem)
        {
            if (id != catalogueItem.Id)
            {
                return BadRequest();
            }

            context.Entry(catalogueItem).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogueItemExists(id))
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

        // POST: api/CatalogueItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogueItem>> PostCatalogueItem(CatalogueItem catalogueItem)
        {
            context.CatalogueItems.Add(catalogueItem);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogueItem", new { id = catalogueItem.Id }, catalogueItem);
        }

        // DELETE: api/CatalogueItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogueItem(int id)
        {
            var catalogueItem = await context.CatalogueItems.FindAsync(id);
            if (catalogueItem == null)
            {
                return NotFound();
            }

            context.CatalogueItems.Remove(catalogueItem);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogueItemExists(int id)
        {
            return context.CatalogueItems.Any(e => e.Id == id);
        }
    }
}
