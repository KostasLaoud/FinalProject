﻿using CertStore.Data;
using CertStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CertStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetUserDetails()
        {
            return await _context.UserDetails.ToListAsync();
        }

        // GET: api/UserDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetUserDetail(int id)
        {
            var userDetail = await _context.UserDetails.FindAsync(id);

            if (userDetail == null)
            {
                return NotFound();
            }

            return userDetail;
        }

        // PUT: api/UserDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetail(int id, UserDetail userDetail)
        {
            if (id != userDetail.DetailId)
            {
                return BadRequest();
            }

            _context.Entry(userDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailExists(id))
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

        // POST: api/UserDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDetail>> PostUserDetail(UserDetail userDetail)
        {
            _context.UserDetails.Add(userDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDetail", new { id = userDetail.DetailId }, userDetail);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetail(int id)
        {
            var userDetail = await _context.UserDetails.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDetailExists(int id)
        {
            return _context.UserDetails.Any(e => e.DetailId == id);
        }
    }
}
