using CertStore.Data;
using CertStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CertStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertExamsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CertExamsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CertExams
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertExam>>> GetCertExams()
        {
            return await _context.CertExams
                .Include(e => e.ExamQuestions) // Include related ExamQuestions
                .ToListAsync();
        }

        // GET: api/CertExams/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CertExam>> GetCertExam(int id)
        {
            var certExam = await _context.CertExams
                .Include(e => e.ExamQuestions) // Include related ExamQuestions
                .FirstOrDefaultAsync(e => e.CertExamId == id);

            if (certExam == null)
            {
                return NotFound();
            }

            return certExam;
        }

        // PUT: api/CertExams/5
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertExam(int id, CertExam certExam)
        {
            if (id != certExam.CertExamId)
            {
                return BadRequest();
            }

            _context.Entry(certExam).State = EntityState.Modified;

            foreach (var question in certExam.ExamQuestions)
            {
                if (question.ItemKey == 0)
                {
                    _context.Entry(question).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(question).State = EntityState.Modified;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertExamExists(id))
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

        // POST: api/CertExams
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CertExam>> PostCertExam(CertExam certExam)
        {
            // Add the CertExam
            _context.CertExams.Add(certExam);
            await _context.SaveChangesAsync();

            // Set CertExamId for each ExamQuestion
            foreach (var question in certExam.ExamQuestions)
            {
                question.CertExamId = certExam.CertExamId;
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCertExam), new { id = certExam.CertExamId }, certExam);
        }

        // DELETE: api/CertExams/5
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertExam(int id)
        {
            var certExam = await _context.CertExams
                .Include(e => e.ExamQuestions)
                .FirstOrDefaultAsync(e => e.CertExamId == id);

            if (certExam == null)
            {
                return NotFound();
            }

            //_context.ExamQuestions.RemoveRange(certExam.ExamQuestions); // Remove related ExamQuestions
            _context.CertExams.Remove(certExam); // Remove CertExam

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertExamExists(int id)
        {
            return _context.CertExams.Any(e => e.CertExamId == id);
        }
    }
}
