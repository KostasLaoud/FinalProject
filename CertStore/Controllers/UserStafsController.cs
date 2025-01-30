using CertStore.Data;
using CertStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CertStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserStafsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserStafsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserStafs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStaf>>> GetUserStafs()
        {
            return await _context.UserStafs.ToListAsync();
        }

        // GET: api/UserStafs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStaf>> GetUserStaf(int id)
        {
            var userStaf = await _context.UserStafs.FindAsync(id);

            if (userStaf == null)
            {
                return NotFound();
            }

            return userStaf;
        }

        // PUT: api/UserStafs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStaf(int id, UserStaf userStaf)
        {
            if (id != userStaf.UserStafId)
            {
                return BadRequest();
            }

            _context.Entry(userStaf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStafExists(id))
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

        // POST: api/UserStafs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserStaf>> PostUserStaf(UserStaf userStaf)
        {
            _context.UserStafs.Add(userStaf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserStaf", new { id = userStaf.UserStafId }, userStaf);
        }

        // DELETE: api/UserStafs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStaf(int id)
        {
            var userStaf = await _context.UserStafs.FindAsync(id);
            if (userStaf == null)
            {
                return NotFound();
            }

            _context.UserStafs.Remove(userStaf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserStafExists(int id)
        {
            return _context.UserStafs.Any(e => e.UserStafId == id);
        }
    }
}
