using CertStore.Data;
using CertStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CertStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExamCategoriesController(AppDbContext context)
        {
            _context = context;
        }
        //[Authorize]
        // GET: api/ExamCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamCategory>>> GetExamCategories()
        {
            return await _context.ExamCategories.ToListAsync();
        }
        //[Authorize]
        // GET: api/ExamCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamCategory>> GetExamCategory(int id)
        {
            var examCategory = await _context.ExamCategories.FindAsync(id);

            if (examCategory == null)
            {
                return NotFound();
            }

            return examCategory;
        }

        //[Authorize(Roles = "Admin")]
        // PUT: api/ExamCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamCategory(int id, ExamCategory examCategory)
        {
            if (id != examCategory.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(examCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamCategoryExists(id))
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

        // POST: api/ExamCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ExamCategory>> PostExamCategory(ExamCategory examCategory)
        {
            _context.ExamCategories.Add(examCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamCategory", new { id = examCategory.CategoryId }, examCategory);
        }

        // DELETE: api/ExamCategories/5
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamCategory(int id)
        {
            var examCategory = await _context.ExamCategories.FindAsync(id);
            if (examCategory == null)
            {
                return NotFound();
            }

            _context.ExamCategories.Remove(examCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamCategoryExists(int id)
        {
            return _context.ExamCategories.Any(e => e.CategoryId == id);
        }
    }
}
