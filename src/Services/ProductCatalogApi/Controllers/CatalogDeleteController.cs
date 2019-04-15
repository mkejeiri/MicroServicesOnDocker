using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Data;
using ProductCatalogApi.Domain.Entities;

namespace ProductCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogDeleteController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public CatalogDeleteController(CatalogDbContext context)
        {
            _context = context;
        }

        // GET: api/CatalogDelete
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogBrand>>> GetCatalogBrands()
        {
            return await _context.CatalogBrands.ToListAsync();
        }

        // GET: api/CatalogDelete/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogBrand>> GetCatalogBrand(int id)
        {
            var catalogBrand = await _context.CatalogBrands.FindAsync(id);

            if (catalogBrand == null)
            {
                return NotFound();
            }

            return catalogBrand;
        }

        // PUT: api/CatalogDelete/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogBrand(int id, CatalogBrand catalogBrand)
        {
            if (id != catalogBrand.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalogBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogBrandExists(id))
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

        // POST: api/CatalogDelete
        [HttpPost]
        public async Task<ActionResult<CatalogBrand>> PostCatalogBrand(CatalogBrand catalogBrand)
        {
            _context.CatalogBrands.Add(catalogBrand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogBrand", new { id = catalogBrand.Id }, catalogBrand);
        }

        // DELETE: api/CatalogDelete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatalogBrand>> DeleteCatalogBrand(int id)
        {
            var catalogBrand = await _context.CatalogBrands.FindAsync(id);
            if (catalogBrand == null)
            {
                return NotFound();
            }

            _context.CatalogBrands.Remove(catalogBrand);
            await _context.SaveChangesAsync();

            return catalogBrand;
        }

        private bool CatalogBrandExists(int id)
        {
            return _context.CatalogBrands.Any(e => e.Id == id);
        }
    }
}
