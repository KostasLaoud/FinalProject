using CertStore.Data;
using CertStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CertStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FullCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FullCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FullCategory>>> GetFullCategories()
        {
            return await _context.FullCategories.ToListAsync();
        }

        // GET: api/FullCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FullCategory>> GetFullCategory(int id)
        {
            var fullCategory = await _context.FullCategories.FindAsync(id);

            if (fullCategory == null)
            {
                return NotFound();
            }

            return fullCategory;
        }

        // PUT: api/FullCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFullCategory(int id, FullCategory fullCategory)
        {
            if (id != fullCategory.FullId)
            {
                return BadRequest();
            }

            _context.Entry(fullCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FullCategoryExists(id))
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

        // POST: api/FullCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FullCategory>> PostFullCategory(FullCategory fullCategory)
        {
            _context.FullCategories.Add(fullCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFullCategory", new { id = fullCategory.FullId }, fullCategory);
        }

        // DELETE: api/FullCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFullCategory(int id)
        {
            var fullCategory = await _context.FullCategories.FindAsync(id);
            if (fullCategory == null)
            {
                return NotFound();
            }

            _context.FullCategories.Remove(fullCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FullCategoryExists(int id)
        {
            return _context.FullCategories.Any(e => e.FullId == id);
        }
    }
}
